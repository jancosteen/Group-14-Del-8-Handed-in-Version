using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.ShiftStatusses
{
    [AutoMapFrom(typeof(ShiftStatus))]
    [AutoMapTo(typeof(ShiftStatus))]
    public class ShiftStatusCandUDto
    {
        //public int ShiftStatusId { get; set; }
        public string ShiftStatus1 { get; set; }

    }
}
