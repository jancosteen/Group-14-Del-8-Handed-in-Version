using Abp.Application.Services;
using MDR_Angular.OrderMate.AdvertisementDates.Dto;

namespace MDR_Angular.OrderMate.AdvertisementDates
{
    public interface IAdvertisementDateAppService : IAsyncCrudAppService<AdvertisementDateDto>
    {
    }
}
