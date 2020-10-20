using Abp.Application.Services;

namespace MDR_Angular.OrderMate.QrCodeSeatings
{
    public interface IQrCodeSeatingAppService : IAsyncCrudAppService<QrCodeSeatingDto>
    {
    }
}
