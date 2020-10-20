using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.ProductTypes
{
    [AutoMapFrom(typeof(ProductType))]
    [AutoMapTo(typeof(ProductType))]
    public class ProductTypeDto : FullAuditedEntityDto<int>
    {
        //public int ProductTypeId { get; set; }
        public string ProductType1 { get; set; }

    }
}
