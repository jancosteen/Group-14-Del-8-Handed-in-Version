using Abp.Application.Services;
using MDR_Angular.OrderMate.Advertisements.Dto;

namespace MDR_Angular.OrderMate.Advertisements
{
    public interface IAdvertisementAppService : IAsyncCrudAppService<AdvertisementDto>
    {
    }
}
