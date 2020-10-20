using Abp.Application.Services;
using MDR_Angular.OrderMate.Allergies.Dto;

namespace MDR_Angular.OrderMate.Allergies
{
    public interface IAllergyAppService : IAsyncCrudAppService<AllergyDto>
    {
    }
}
