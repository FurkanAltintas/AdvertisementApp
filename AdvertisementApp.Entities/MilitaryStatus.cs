using System.Collections.Generic;

namespace AdvertisementApp.Entities
{
    public class MilitaryStatus : BaseEntity<int>
    {
        public string Definition { get; set; }
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
