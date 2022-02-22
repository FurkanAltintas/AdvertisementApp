using System;

namespace AdvertisementApp.Entities
{
    public class ProvidedService : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
