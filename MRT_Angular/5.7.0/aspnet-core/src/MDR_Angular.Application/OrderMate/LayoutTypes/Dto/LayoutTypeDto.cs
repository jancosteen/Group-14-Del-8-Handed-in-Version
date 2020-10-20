using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.LayoutTypes.Dto
{
    [AutoMapFrom(typeof(LayoutType))]
    [AutoMapTo(typeof(LayoutType))]
    public class LayoutTypeDto : FullAuditedEntityDto<int>
    {
        public string LayoutType1 { get; set; }

    }
}
