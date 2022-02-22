using System.Collections.Generic;

namespace AdvertisementApp.Common
{
    public interface ITest
    {
        IResponse<List<ApplicationUser>> Users();
    }

    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
