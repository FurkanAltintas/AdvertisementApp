using AdvertisementApp.Dtos;
using AdvertisementApp.UI.Models;
using AutoMapper;

namespace AdvertisementApp.UI.Mappings.AutoMapper
{
    public class AdvertisementAppUserProfile :  Profile
    {
        public AdvertisementAppUserProfile()
        {
            CreateMap<AdvertisementAppUserCreateModel, AdvertisementAppUserCreateDto>().ReverseMap();
        }
    }
}
