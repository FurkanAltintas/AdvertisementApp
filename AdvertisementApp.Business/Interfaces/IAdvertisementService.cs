using AdvertisementApp.Common;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementService : IService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>
    {
        Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync();
    }
}
