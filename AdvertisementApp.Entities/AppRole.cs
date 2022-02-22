using System.Collections.Generic;

namespace AdvertisementApp.Entities
{
    public class AppRole : BaseEntity<int>
    {
        public string Definition { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
