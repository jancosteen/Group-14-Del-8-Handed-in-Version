using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.AdvertisementPrices.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace MDR_Angular.OrderMate.AdvertisementPrices
{
    //[AbpAuthorize(PermissionNames.Pages_AP)]
    public class AdvertisementPriceAppService : AsyncCrudAppService<
        AdvertisementPrice, AdvertisementPriceDto, int, PagedAndSortedResultRequestDto, AdvertisementPriceDto>, IAdvertisementPriceAppService
    {
        public AdvertisementPriceAppService(IRepository<AdvertisementPrice> repository) : base(repository) { }

    }
}
