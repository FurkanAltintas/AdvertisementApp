using AdvertisementApp.Dtos.Interfaces;
using System;

namespace AdvertisementApp.Dtos
{
    public class ProvidedServiceListDto : IDto // sen bir aslında bir Dto'sun
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
