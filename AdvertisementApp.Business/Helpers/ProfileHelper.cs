using AdvertisementApp.Business.Mappings.AutoMapper;
using AutoMapper;
using System.Collections.Generic;

namespace AdvertisementApp.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new ProvidedServiceProfile(),
                new AdvertisementProfile(),
                new AppUserProfile(),
                new GenderProfile(),
                new AppRoleProfile(),
                new AdvertisementAppUserProfile(),
                new AdvertisementAppUserStatusProfile(),
                new MilitaryStatusProfile()
            };

            //var mapperConfiguration = new MapperConfiguration(opt =>
            //{
            //    opt.AddProfile(new ProvidedServiceProfile());
            //    opt.AddProfile(new AdvertisementProfile());
            //    opt.AddProfile(new AppUserProfile());
            //    opt.AddProfile(new GenderProfile());
            //});
        }
    }
}
