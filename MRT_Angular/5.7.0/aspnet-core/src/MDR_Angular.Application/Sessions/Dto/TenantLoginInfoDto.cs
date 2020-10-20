using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.MultiTenancy;

namespace MDR_Angular.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
