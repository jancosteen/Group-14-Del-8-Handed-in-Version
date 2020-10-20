using Abp.Application.Services;

namespace MDR_Angular.OrderMate.SpecialPrices
{
    public interface ISpecialPriceAppService : IAsyncCrudAppService<SpecialPriceDto>
    {
    }
}
