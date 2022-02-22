using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AdvertisementApp.UI.Extensions
{
    public static class SelectListExtensions
    {
        public static SelectList SelectListModel<T>(List<T> model, string value, string text)
        {
            return new SelectList(model, value, text);
        }
    }
}
