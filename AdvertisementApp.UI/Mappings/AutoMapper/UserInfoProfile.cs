using AdvertisementApp.Dtos;
using AdvertisementApp.UI.Base;
using AutoMapper;

namespace AdvertisementApp.UI.Mappings.AutoMapper
{
    public class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            CreateMap<UserInfo, AppUserUpdateDto>().ReverseMap();
        }
    }
}
