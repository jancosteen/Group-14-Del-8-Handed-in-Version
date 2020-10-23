using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Countries;
using MDR_Angular.OrderMate.Provinces;
using MDR_Angular.OrderMate.Restaurants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MDR_Angular.OrderMate.Cities
{
    public class City:FullAuditedEntity<int>
    {
        public string CityName { get; set; }
        


        
        public ICollection<Restaurant> Restaurants { get; set; }
        
    }
}
