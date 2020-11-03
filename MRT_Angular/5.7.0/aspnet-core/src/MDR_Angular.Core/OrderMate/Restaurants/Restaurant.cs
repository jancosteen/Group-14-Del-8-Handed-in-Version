using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Advertisements;
using MDR_Angular.OrderMate.Cities;
using MDR_Angular.OrderMate.Countries;
using MDR_Angular.OrderMate.Employees;
using MDR_Angular.OrderMate.MenuRestaurants;
using MDR_Angular.OrderMate.Menus;
using MDR_Angular.OrderMate.Provinces;
using MDR_Angular.OrderMate.QrCodes;
using MDR_Angular.OrderMate.ReservationRestaurants;
using MDR_Angular.OrderMate.Reservations;
using MDR_Angular.OrderMate.RestaurantAdvertisements;
using MDR_Angular.OrderMate.RestaurantFacilityRefs;
using MDR_Angular.OrderMate.RestaurantImages;
using MDR_Angular.OrderMate.RestaurantStatusses;
using MDR_Angular.OrderMate.RestaurantTypeReferences;
using MDR_Angular.OrderMate.SeatingLayouts;
using MDR_Angular.OrderMate.SocialMedias;
using MDR_Angular.OrderMate.UserComments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.Restaurants
{
    public class Restaurant : FullAuditedEntity<int>
    {
        //public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantUrl { get; set; }
        public string RestaurantDescription { get; set; }
        public string RestaurantAddressLine1 { get; set; }
        public string ResaturantAddressLine2 { get; set; }
        public string RestaurantPostalCode { get; set; }        
        public int CountryIdFk { get; set; }
        public int ProvinceIdFk { get; set; }
        public int CityIdFk { get; set; }
        public int? RestaurantStatusIdFk { get; set; }

        [ForeignKey("RestaurantStatusIdFk")]
        public virtual RestaurantStatus RestaurantStatusIdFkNavigation { get; set; }
        
        [ForeignKey("ProvinceIdFk")]
        public virtual Province ProvinceIdFkNavigation { get; set; }
        [ForeignKey("CityIdFk")]
        public virtual City CityIdFkNavigation { get; set; }
        [ForeignKey("CountryIdFk")]
        public virtual Country CountryIdFkNavigation { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<QrCode> QrCode { get; set; }
        public virtual ICollection<RestaurantFacilityRef> ResaurantFacilityRef { get; set; }
        //public virtual ICollection<ReservationRestaurant> ReservationRestaurant { get; set; }
        //public virtual ICollection<RestaurantAdvertisement> RestaurantAdvertisement { get; set; }
        public virtual ICollection<RestaurantImage> RestaurantImage { get; set; }
        public virtual ICollection<RestaurantTypeRef> RestaurantTypeReference { get; set; }
        public virtual ICollection<SeatingLayout> SeatingLayout { get; set; }
        public virtual ICollection<UserComment> UserComment { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
        public virtual ICollection<SocialMedia> SocialMedias { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }

    }
}
