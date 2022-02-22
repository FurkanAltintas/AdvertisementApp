using AdvertisementApp.Common.Enums;
using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity<int>
    {
        private readonly AdvertisementContext _context;

        public Repository(AdvertisementContext context)
        {
            _context = context;
        }

        // bütün veriyi getirme
        // bütün veriyi sıralayarak getirme
        // bütün veriyi filter getirme
        // include ile kullanma
        // asnotracking()

        #region GetAll()
        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ?
                await _context.Set<T>().AsNoTracking().ToListAsync() :
                await _context.Set<T>().AsNoTracking().Where(filter).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC) // default hali DESC olarak ayarladık
        {
            return orderByType == OrderByType.ASC ?
                await _context.Set<T>().OrderBy(selector).AsNoTracking().ToListAsync() :
                await _context.Set<T>().OrderByDescending(selector).AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ?
                await _context.Set<T>().Where(filter).AsNoTracking().OrderBy(selector).ToListAsync() :
                await _context.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selector).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType, Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetQueryAsync();

            if (filter != null)
                query = query.Where(filter);

            if (orderByType == OrderByType.ASC)
                query = query.AsNoTracking().OrderBy(selector);
            else
                query = query.AsNoTracking().OrderByDescending(selector);

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }
        #endregion

        #region Create, Update, Remove
        public async Task RemoveAsync(T entity)
        {
            await Task.Run(() => { _context.Set<T>().Remove(entity); });
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity, T unchanged)
        {
            await Task.Run(() => { _context.Entry(unchanged).CurrentValues.SetValues(entity); });
        }
        #endregion

        public async Task<T> FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) :
                await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public IQueryable<T> GetQueryAsync()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
