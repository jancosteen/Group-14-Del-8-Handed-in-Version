using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.ReservationRestaurants
{
    //[AbpAuthorize(PermissionNames.Pages_RR)]
    public class ReservationRestaurantAppService : AsyncCrudAppService<
        ReservationRestaurant, ReservationRestaurantDto, int, PagedAndSortedResultRequestDto, ReservationRestaurantDto>, IReservationRestaurantAppService
    {
        public ReservationRestaurantAppService(IRepository<ReservationRestaurant> repository) : base(repository) { }
    }
}
