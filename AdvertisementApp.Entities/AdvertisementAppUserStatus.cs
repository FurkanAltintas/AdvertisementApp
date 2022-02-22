using System.Collections.Generic;

namespace AdvertisementApp.Entities
{
    public class AdvertisementAppUserStatus : BaseEntity<int>
    {
        public string Definition { get; set; }

        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
