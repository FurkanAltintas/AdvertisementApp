using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace AdvertisementApp.UI.Extensions
{
    public static class UserExtensions
    {
        public static int UserKey(this Controller controller)
        {
            return int.Parse((controller.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)).Value);
        }

        public static object UserType(this Controller controller, string type)
        {
            return controller.User.Claims.FirstOrDefault(c => c.Type == type).Value;
        }

        public static string ClaimType(this Controller controller, string type)
        {
            return controller.User.Claims.FirstOrDefault(c => c.Type == type)?.Value;
        }
    }
}
