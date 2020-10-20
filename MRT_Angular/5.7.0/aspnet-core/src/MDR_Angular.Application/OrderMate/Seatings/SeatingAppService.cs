using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.Seatings
{
    //[AbpAuthorize(PermissionNames.Pages_S)]
    public class SeatingAppService : AsyncCrudAppService<
        Seating, SeatingDto, int, PagedAndSortedResultRequestDto, SeatingDto>, ISeatingAppService
    {
        public SeatingAppService(IRepository<Seating> repository) : base(repository) { }
    }
}
