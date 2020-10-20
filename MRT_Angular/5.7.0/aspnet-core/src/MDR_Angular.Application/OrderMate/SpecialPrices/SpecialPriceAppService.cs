using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.SpecialPrices
{
    //[AbpAuthorize(PermissionNames.Pages_SPP)]
    public class SpecialPriceAppService : AsyncCrudAppService<
        SpecialPrice, SpecialPriceDto, int, PagedAndSortedResultRequestDto, SpecialPriceDto>, ISpecialPriceAppService
    {
        public SpecialPriceAppService(IRepository<SpecialPrice> repository) : base(repository) { }
    }
}
