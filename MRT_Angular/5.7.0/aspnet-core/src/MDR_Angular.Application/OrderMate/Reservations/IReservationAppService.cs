using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace MDR_Angular.OrderMate.Reservations
{
    public interface IReservationAppService : IAsyncCrudAppService<ReservationDto>
    {
        ListResultDto<ReservationDto> GetReservationById(int id);

    }
}
