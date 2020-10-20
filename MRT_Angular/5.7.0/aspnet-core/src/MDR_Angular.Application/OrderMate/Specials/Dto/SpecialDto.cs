using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.Specials
{
    [AutoMapFrom(typeof(Special))]
    [AutoMapTo(typeof(Special))]
    public class SpecialDto : FullAuditedEntityDto<int>
    {
        //public int SpecialId { get; set; }
        public DateTime SpecialStartDate { get; set; }
        public DateTime SpecialEndDate { get; set; }
        public string SpecialName { get; set; }
        public string SpecialDescription { get; set; }
        public Boolean isActive { get; set; }


    }
}
