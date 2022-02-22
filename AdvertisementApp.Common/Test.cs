using System.Collections.Generic;
using System.Linq;

namespace AdvertisementApp.Common
{
    public class Test : ITest
    {
        public IResponse<List<ApplicationUser>> Users()
        {
            var users = new List<ApplicationUser>();

            if (users.Count() > -1)
            {
                return new Response<List<ApplicationUser>>(ResponseType.Success, "İşleminiz başarılı");
            }
            else
            {
                return new Response<List<ApplicationUser>>(ResponseType.NotFound, "Kullanıcınız bulunmamaktadır");
            }
        }
    }
}
