using Abp.Application.Services;
using MDR_Angular.OrderMate.AdvertisementPrices.Dto;

namespace MDR_Angular.OrderMate.AdvertisementPrices
{
    public interface IAdvertisementPriceAppService : IAsyncCrudAppService<AdvertisementPriceDto>
    {
    }
}
