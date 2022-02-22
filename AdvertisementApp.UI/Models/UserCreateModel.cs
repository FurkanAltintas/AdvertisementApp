using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvertisementApp.UI.Models
{
    public class UserCreateModel
    {
        public int GenderId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }

        public SelectList Genders { get; set; }
    }
}
