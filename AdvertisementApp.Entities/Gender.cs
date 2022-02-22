using System.Collections.Generic;

namespace AdvertisementApp.Entities
{
    public class Gender : BaseEntity<int>
    {
        public string Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
