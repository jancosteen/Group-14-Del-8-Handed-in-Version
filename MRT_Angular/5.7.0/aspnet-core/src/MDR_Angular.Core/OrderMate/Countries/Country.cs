using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Cities;
using MDR_Angular.OrderMate.Provinces;
using MDR_Angular.OrderMate.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Countries
{
    public class Country: FullAuditedEntity<int>
    {
        public string CountryName { get; set; }

        
        public ICollection<Restaurant> Restaurants { get; set; }
        public ICollection<Province> Provinces { get; set; }
    }
}
