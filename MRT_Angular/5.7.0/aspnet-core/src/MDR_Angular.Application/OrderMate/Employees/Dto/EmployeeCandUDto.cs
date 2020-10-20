using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.Employees.Dto
{
    [AutoMapFrom(typeof(Employee))]
    [AutoMapTo(typeof(Employee))]
    public class EmployeeCandUDto
    {
        public string EmployeeIdNumber { get; set; }
        public int? RestaurantIdFk { get; set; }
    }
}
