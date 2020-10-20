using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.ReservationStatusses
{
    //[AbpAuthorize(PermissionNames.Pages_RS)]
    public class ReservationStatusAppService : AsyncCrudAppService<
        ReservationStatus, ReservationStatusDto, int, PagedAndSortedResultRequestDto, ReservationStatusDto>, IReservationStatusAppService
    {
        public ReservationStatusAppService(IRepository<ReservationStatus> repository) : base(repository) { }
    }
}
