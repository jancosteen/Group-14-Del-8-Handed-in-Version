using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.Menus
{
    [AutoMapFrom(typeof(Menu))]
    [AutoMapTo(typeof(Menu))]
    public class MenuCandUDto
    {
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public DateTime MenuDateCreated { get; set; }
        public TimeSpan? MenuTimeActiveFrom { get; set; }
        public TimeSpan? MenuTimeActiveTo { get; set; }
    }
}
