using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.SupplierOrderLines
{
    [AutoMapFrom(typeof(SupplierOrderLine))]
    [AutoMapTo(typeof(SupplierOrderLine))]
    public class SupplierOrderLineDto : FullAuditedEntityDto<int>
    {
        //public int SupplierOrderLineId { get; set; }
        public int ProductIdFk { get; set; }
        public int SupplierOrderIdFk { get; set; }
        public int DeliveryLeadTime { get; set; }
        public double ProductStandardPrice { get; set; }
        public double DiscountAgreement { get; set; }
        public int OrderedQty { get; set; }


    }
}
