using Abp.Application.Services;
using MDR_Angular.MultiTenancy.Dto;

namespace MDR_Angular.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

