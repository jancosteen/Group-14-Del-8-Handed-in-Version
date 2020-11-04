using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Reservations.Dto
{
    public class SmsDto
    {
        public string reservationDateCreated { get; set; }
        public string reservationDateReserved { get; set; }
        public string restaurantName { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public string reservationStatus { get; set; }
    }
}
