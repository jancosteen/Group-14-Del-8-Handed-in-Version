using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace MDR_Angular.OrderMate.ProductCategories.Dto
{
    [AutoMapFrom(typeof(ProductCategory))]
    [AutoMapTo(typeof(ProductCategory))]
    public class ProductCategoryDto : FullAuditedEntityDto<int>
    {
        public string ProductCategory1 { get; set; }
    }
}
