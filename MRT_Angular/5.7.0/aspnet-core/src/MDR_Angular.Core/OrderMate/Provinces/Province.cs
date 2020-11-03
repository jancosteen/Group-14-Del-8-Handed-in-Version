using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Cities;
using MDR_Angular.OrderMate.Countries;
using MDR_Angular.OrderMate.Restaurants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MDR_Angular.OrderMate.Provinces
{
    public class Province : FullAuditedEntity<int>
    {
        public string ProvinceName { get; set; }

        public int CountryIdFk { get; set; }

        [ForeignKey("CountryIdFk")]
        public virtual Country CountryIdFkNavigation { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<Restaurant> Restaurants {get;set;}

        
    }
}
