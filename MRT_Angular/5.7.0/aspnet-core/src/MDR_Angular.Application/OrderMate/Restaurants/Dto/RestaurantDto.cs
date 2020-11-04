using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.Advertisements.Dto;
using MDR_Angular.OrderMate.Cities.Dto;
using MDR_Angular.OrderMate.Countries.Dto;
using MDR_Angular.OrderMate.Employees.Dto;
using MDR_Angular.OrderMate.MenuRestaurants.Dto;
using MDR_Angular.OrderMate.Menus;
using MDR_Angular.OrderMate.Provinces.Dto;
using MDR_Angular.OrderMate.QrCodes;
using MDR_Angular.OrderMate.ReservationRestaurants;
using MDR_Angular.OrderMate.Reservations;
using MDR_Angular.OrderMate.RestaurantAdvertisements;
using MDR_Angular.OrderMate.RestaurantFacilityRefs;
using MDR_Angular.OrderMate.RestaurantImages;
using MDR_Angular.OrderMate.RestaurantStatusses;
using MDR_Angular.OrderMate.RestaurantTypeReferences;
using MDR_Angular.OrderMate.SeatingLayouts;
using MDR_Angular.OrderMate.UserComments;
using System;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.Restaurants
{
    [AutoMapFrom(typeof(Restaurant))]
    [AutoMapTo(typeof(Restaurant))]
    public class RestaurantDto : FullAuditedEntityDto<int>
    {
        //public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantUrl { get; set; }
        public string RestaurantDescription { get; set; }
        //public DateTime? RestaurantDateCreated { get; set; }
        public string RestaurantAddressLine1 { get; set; }
        public string ResaturantAddressLine2 { get; set; }
        
        public string RestaurantPostalCode { get; set; }
        
        public int CountryIdFk { get; set; }
        public int ProvinceIdFk { get; set; }
        public int CityIdFk { get; set; }
        public int? RestaurantStatusIdFk { get; set; }

        public virtual RestaurantStatusCandUDto RestaurantStatusIdFkNavigation { get; set; }

        public virtual ICollection<EmployeeDto> Employee { get; set; }
        //public virtual ICollection<MenuRestaurantDto> MenuRestaurant { get; set; }
        //public virtual ICollection<MenuDto> Menu { get; set; }

        //public virtual ICollection<QrCodeDto> QrCode { get; set; }
        public virtual ICollection<RestaurantFacilityRefCandUDto> ResaurantFacilityRef { get; set; }
        //public virtual ICollection<ReservationRestaurantDto> ReservationRestaurant { get; set; }
        //public virtual ICollection<RestaurantAdvertisementDto> RestaurantAdvertisement { get; set; }
        public virtual ICollection<RestaurantImageCandUDto> RestaurantImage { get; set; }
        public virtual ICollection<RestaurantTypeRefCandUDto> RestaurantTypeReference { get; set; }
        public virtual ICollection<SeatingLayoutCandUDto> SeatingLayout { get; set; }
        public virtual ICollection<UserCommentCandUDto> UserComment { get; set; }
        //public virtual ICollection<ReservationDto> Reservation { get; set; }
        public virtual ICollection<AdvertisementCandUDto> Advertisements { get; set; }

        
        public virtual CountryCandUDto CountryIdFkNavigation { get; set; }
        public virtual ProvinceCandUDto ProvinceIdFkNavigation { get; set; }
        public virtual CityCandUDto CityIdFkNavigation { get; set; }


    }
}
