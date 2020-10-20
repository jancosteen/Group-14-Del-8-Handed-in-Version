using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.SeatingLayouts
{
    //[AbpAuthorize(PermissionNames.Pages_SL)]
    public class SeatingLayoutAppService : AsyncCrudAppService<
        SeatingLayout, SeatingLayoutDto, int, PagedAndSortedResultRequestDto, SeatingLayoutDto>, ISeatingLayoutAppService
    {
        public SeatingLayoutAppService(IRepository<SeatingLayout> repository) : base(repository) { }
    }
}
