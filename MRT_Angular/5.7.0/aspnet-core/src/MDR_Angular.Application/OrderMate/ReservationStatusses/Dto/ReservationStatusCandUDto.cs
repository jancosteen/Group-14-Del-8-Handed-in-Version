﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.ReservationStatusses
{
    [AutoMapFrom(typeof(ReservationStatus))]
    [AutoMapTo(typeof(ReservationStatus))]
    public class ReservationStatusCandUDto: EntityDto<int>
    {
        //public int ReservationStatusId { get; set; }
        public string ReservationStatus1 { get; set; }


    }
}
