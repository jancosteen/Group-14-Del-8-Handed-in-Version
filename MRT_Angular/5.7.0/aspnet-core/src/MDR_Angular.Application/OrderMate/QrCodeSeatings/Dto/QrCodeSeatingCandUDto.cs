using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.QrCodeSeatings
{
    [AutoMapFrom(typeof(QrCodeSeating))]
    [AutoMapTo(typeof(QrCodeSeating))]
    public class QrCodeSeatingCandUDto
    {
        //public int QrCodeSeatingId { get; set; }
        public int NrOfPeople { get; set; }
        public int QrCodeIdFk { get; set; }
        public int SeatingIdFk { get; set; }
        public int? OrderIdFk { get; set; }

    }
}
