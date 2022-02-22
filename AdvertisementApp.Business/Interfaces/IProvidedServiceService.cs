using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IProvidedServiceService : IService<ProvidedServiceCreateDto,  ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>
    {
    }
}
