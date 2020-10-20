using Abp.AutoMapper;


namespace MDR_Angular.OrderMate.ProductCategories.Dto
{
    [AutoMapFrom(typeof(ProductCategory))]
    [AutoMapTo(typeof(ProductCategory))]
    public class ProductCategoryCandUDto
    {
        public string ProductCategory1 { get; set; }
    }
}
