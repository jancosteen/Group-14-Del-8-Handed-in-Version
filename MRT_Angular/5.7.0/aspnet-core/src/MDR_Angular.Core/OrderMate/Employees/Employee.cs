using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.AttendanceSheets;
using MDR_Angular.OrderMate.EmployeeShifts;
using MDR_Angular.OrderMate.ProductStockTakes;
using MDR_Angular.OrderMate.ProductsWrittenOff;
using MDR_Angular.OrderMate.Restaurants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.Employees
{
    public class Employee : FullAuditedEntity<int>
    {
        //public int EmployeeId { get; set; }
        public string EmployeeIdNumber { get; set; }
        public int? RestaurantIdFk { get; set; }

        [ForeignKey("RestaurantIdFk")]
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        public virtual ICollection<AttendanceSheet> AttendanceSheet { get; set; }
        public virtual ICollection<EmployeeShift> EmployeeShift { get; set; }
        public virtual ICollection<ProductStockTake> ProductStockTake { get; set; }
        public virtual ICollection<ProductWrittenOff> ProductWrittenOff { get; set; }
    }
}
