using System.Collections.Generic;

namespace AdvertisementApp.Entities
{
    public class AppUser : BaseEntity<int>
    {
        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
