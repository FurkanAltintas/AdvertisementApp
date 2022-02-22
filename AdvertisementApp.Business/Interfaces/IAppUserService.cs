using AdvertisementApp.Common;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId);
        Task<IResponse<AppUserListDto>> CheckUser(AppUserLoginDto dto);
        Task<IResponse<List<AppRoleListDto>>> GetRoleByUserIdAsync(int userId);
    }
}
