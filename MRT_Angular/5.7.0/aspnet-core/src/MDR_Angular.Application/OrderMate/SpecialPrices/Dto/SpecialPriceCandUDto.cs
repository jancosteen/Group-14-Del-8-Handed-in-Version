using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.SpecialPrices
{
    [AutoMapFrom(typeof(SpecialPrice))]
    [AutoMapTo(typeof(SpecialPrice))]
    public class SpecialPriceCandUDto
    {
        //public int SpecialPriceId { get; set; }
        public double SpecialPrice1 { get; set; }
        public DateTime SpecialPriceDateUpdated { get; set; }
        public int? SpecialIdFk { get; set; }


    }
}
