using Abp.Application.Services;

namespace MDR_Angular.OrderMate.QrCodes
{
    public interface IQrCodeAppService : IAsyncCrudAppService<QrCodeDto>
    {
    }
}
