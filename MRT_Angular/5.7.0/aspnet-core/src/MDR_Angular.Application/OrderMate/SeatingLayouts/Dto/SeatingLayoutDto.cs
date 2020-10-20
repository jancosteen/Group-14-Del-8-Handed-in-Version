using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.SeatingLayouts
{
    [AutoMapFrom(typeof(SeatingLayout))]
    [AutoMapTo(typeof(SeatingLayout))]
    public class SeatingLayoutDto : FullAuditedEntityDto<int>
    {
        //public int SeatingLayoutId { get; set; }
        public int RestaurantIdFk { get; set; }
        public int LayoutTypeIdFk { get; set; }
        public string SeatingLayoutQty { get; set; }


    }
}
