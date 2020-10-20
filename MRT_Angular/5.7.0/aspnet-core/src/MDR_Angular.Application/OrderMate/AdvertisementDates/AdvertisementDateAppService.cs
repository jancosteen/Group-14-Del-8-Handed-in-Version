using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.AdvertisementDates.Dto;

namespace MDR_Angular.OrderMate.AdvertisementDates
{
    //[AbpAuthorize(PermissionNames.Pages_AD)]
    public class AdvertisementDateAppService : AsyncCrudAppService<
        AdvertisementDate, AdvertisementDateDto, int, PagedAndSortedResultRequestDto, AdvertisementDateDto>, IAdvertisementDateAppService
    {
        public AdvertisementDateAppService(IRepository<AdvertisementDate> repository) : base(repository) { }
    }
}
