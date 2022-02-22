using AdvertisementApp.Business.Extensions;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Services
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        private readonly IUow _uow;
        private readonly IValidator<AdvertisementAppUserCreateDto> _createDtoValidator;
        private readonly IMapper _mapper;

        public AdvertisementAppUserService(IUow uow, IValidator<AdvertisementAppUserCreateDto> createDtoValidator, IMapper mapper)
        {
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _mapper = mapper;
        }

        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(a => a.AppUserId == dto.AppUserId && a.AdvertisementId == dto.AdvertisementId);
                // Bu kullanıcı, aynı iş ilanına bir daha başvurmuş mu onu kontrol ediyoruz

                if (control == null)
                {
                    var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                    await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);
                    await _uow.SaveChanges();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }

                List<CustomValidationError> errors = new()
                {
                    new()
                    {
                        PropertyName = "",
                        ErrorMessage = "Daha önce başvurulan ilana başvurulamaz"
                    }
                };

                return new Response<AdvertisementAppUserCreateDto>(dto, errors);
            }

            return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertCustomValidationError());
        }

        public async Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQueryAsync();
            var list = await query.Include(a => a.Advertisement)
                 .Include(a => a.AdvertisementAppUserStatus)
                 .Include(a => a.MilitaryStatus)
                 .Include(a => a.AppUser)
                 .ThenInclude(a => a.Gender) // AppUser içerisindeyiz
                 .Where(a => a.AdvertisementAppUserStatusId == (int)type)
                 .ToListAsync();
            return _mapper.Map<List<AdvertisementAppUserListDto>>(list);
        }

        public async Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            var unchanged = await _uow.GetRepository<AdvertisementAppUser>().FindAsync(advertisementAppUserId);
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQueryAsync();
            var entity = await query.SingleOrDefaultAsync(a => a.Id == advertisementAppUserId);
            entity.AdvertisementAppUserStatusId = (int)type;
            await _uow.SaveChanges();
        }
    }
}
