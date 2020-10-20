using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MDR_Angular.OrderMate.Reservations
{
    //[AbpAuthorize(PermissionNames.Pages_R)]
    public class ReservationAppService : AsyncCrudAppService<
        Reservation, ReservationDto, int, PagedAndSortedResultRequestDto, ReservationDto>, IReservationAppService
    {
        public ReservationAppService(IRepository<Reservation> repository) : base(repository) { }

        public ListResultDto<ReservationDto> GetReservationById(int id)
        {
            var reservation = Repository
                .GetAll().Where(x => x.Id == id)
                .Include(i => i.UserIdFkNavigation)
                .Include(i => i.RestaurantIdFkNavigation)
                .Include(i => i.ReservationStatusIdFkNavigation)
                .Include(i => i.Seating)
                

                .ToList();
            return new ListResultDto<ReservationDto>(ObjectMapper.Map<List<ReservationDto>>(reservation));
        }

        public ListResultDto<ReservationDto> GetReservationByUserId(int id)
        {
            var reservation = Repository
                .GetAll().Where(x => x.UserIdFk == id)
                .Include(i => i.UserIdFkNavigation)
                .Include(i => i.RestaurantIdFkNavigation)
                .Include(i => i.ReservationStatusIdFkNavigation)
                .Include(i => i.Seating)


                .ToList();
            return new ListResultDto<ReservationDto>(ObjectMapper.Map<List<ReservationDto>>(reservation));
        }

        protected override IQueryable<Reservation> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                //.Include(i => i.ReservationRestaurant).ThenInclude(x => x.RestaurantIdFkNavigation)
                .Include(i => i.ReservationStatusIdFkNavigation)
                .Include(i => i.Seating)
                .Include(i => i.UserIdFkNavigation)
                .Include(i => i.RestaurantIdFkNavigation);
        }

        
    }
}
