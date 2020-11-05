using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.OrderLines.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace MDR_Angular.OrderMate.OrderLines
{
    //[AbpAuthorize(PermissionNames.Pages_OL)]
    public class OrderLineAppService : AsyncCrudAppService<
        OrderLine, OrderLineDto, int, PagedAndSortedResultRequestDto, OrderLineDto>, IOrderLineAppService
    {
        public OrderLineAppService(IRepository<OrderLine> repository) : base(repository) { }

        public ListResultDto<OrderLineDto> GetOrderLineByOrderId(int id)
        {
            var orderLines = Repository
                .GetAll().Where(x => x.OrderIdFk == id)
                .Include(i => i.MenuItemIdFkNavigation)
               .Include(i => i.UserIdFkNavigation)
                //.Include(i => i.MenuItemIdFkNavigation).ThenInclude(i => i.MenuItemPriceIdFkNavigation)

                .ToList();
            return new ListResultDto<OrderLineDto>(ObjectMapper.Map<List<OrderLineDto>>(orderLines));
        }

        protected override IQueryable<OrderLine> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .Include(i => i.MenuItemIdFkNavigation)
                //.Include(i => i.MenuItemIdFkNavigation).ThenInclude(i=>i.MenuItemPriceIdFkNavigation)
                .Include(i => i.UserIdFkNavigation);
        }


        [HttpGet]
        public List<dynamic> TodayOrders()
        {
            var orderlines = Repository.GetAll()
                .Include(x => x.MenuItemIdFkNavigation)
                .ToList();

            //total number of orders everyday for a week

            DateTime nowDate = DateTime.Now;
            DateTime yestarday = new DateTime(nowDate.Year, nowDate.Month, nowDate.Day-1);
            int today =0;
            int yest =0;
            List<object> list = new List<object>();


            foreach (OrderLine obj in orderlines)
            {
                if(obj.OrderIdFkNavigation.OrderDateCompleted == nowDate)
                {
                    today += 1;
                }else if (obj.OrderIdFkNavigation.OrderDateCompleted == nowDate)
                {
                    yest += 1;
                }
            }

            dynamic Count = new ExpandoObject();
            Count.Day = "Today";
            Count.Num = today;
            list.Add(Count);

            dynamic Count1 = new ExpandoObject();
            Count1.Day = "Yestarday";
            Count1.Num = yest;
            list.Add(Count1);

            return list;
        }



        [HttpGet]
        public List<dynamic> TotalNumberOfSales()
        {
            var orderlines = Repository.GetAll()
                .Include(x => x.MenuItemIdFkNavigation)
                .ToList();
            //dates to check
            DateTime nowDate = DateTime.Now;
            DateTime January = new DateTime(nowDate.Year, 01, 01);
            DateTime January1 = new DateTime(nowDate.Year, 01, 31);
            DateTime Feb = new DateTime(nowDate.Year, 02, 01);
            DateTime Feb1 = new DateTime(nowDate.Year, 02, 27);
            DateTime March = new DateTime(nowDate.Year, 03, 01);
            DateTime March1 = new DateTime(nowDate.Year, 03, 31);
            DateTime April = new DateTime(nowDate.Year, 04, 01);
            DateTime April1 = new DateTime(nowDate.Year, 04, 30);
            DateTime May = new DateTime(nowDate.Year, 05, 01);
            DateTime May1 = new DateTime(nowDate.Year, 05, 31);
            DateTime June = new DateTime(nowDate.Year, 06, 01);
            DateTime June1 = new DateTime(nowDate.Year, 06, 30);
            DateTime July = new DateTime(nowDate.Year, 07, 01);
            DateTime July1 = new DateTime(nowDate.Year, 07, 31);
            DateTime Aug = new DateTime(nowDate.Year, 08, 01);
            DateTime Aug1 = new DateTime(nowDate.Year, 08, 31);
            DateTime Sep = new DateTime(nowDate.Year, 09, 01);
            DateTime Sep1 = new DateTime(nowDate.Year, 09, 30);
            DateTime Oct = new DateTime(nowDate.Year, 10, 01);
            DateTime Oct1 = new DateTime(nowDate.Year, 10, 31);
            DateTime Nov = new DateTime(nowDate.Year, 11, 01);
            DateTime Nov1 = new DateTime(nowDate.Year, 11, 30);
            DateTime Dec = new DateTime(nowDate.Year, 12, 01);



            //amounts

            float janSales = 0;
            float FebSales = 0;
            float MarchSales = 0;
            float AprilSales = 0;
            float MaySales = 0;
            float JuneSales = 0;
            float JulySales = 0;
            float AugSales = 0;
            float SepSales = 0;
            float OctSales = 0;
            float NovSales = 0;
            float DecSales = 0;


            //  dynamic outObject = new ExpandoObject();
            List<object> list = new List<object>();


            foreach (OrderLine obj in orderlines)
            {
                if (obj.OrderIdFkNavigation.OrderDateCompleted >= January && obj.OrderIdFkNavigation.OrderDateCompleted <= January1)
                {
                    janSales += obj.MenuItemIdFkNavigation.MenuItemPrice * obj.ItemQty;
                }
                else if (obj.OrderIdFkNavigation.OrderDateCompleted >= Feb && obj.OrderIdFkNavigation.OrderDateCompleted <= Feb1)
                {
                    FebSales += (obj.MenuItemIdFkNavigation.MenuItemPrice * obj.ItemQty);
                }
                else if (obj.OrderIdFkNavigation.OrderDateCompleted >= March && obj.OrderIdFkNavigation.OrderDateCompleted <= March1)
                {
                    MarchSales += (obj.MenuItemIdFkNavigation.MenuItemPrice * obj.ItemQty);
                }
                else if (obj.OrderIdFkNavigation.OrderDateCompleted >= April && obj.OrderIdFkNavigation.OrderDateCompleted <= April1)
                {
                    AprilSales += (obj.MenuItemIdFkNavigation.MenuItemPrice * obj.ItemQty);
                }
                else if (obj.OrderIdFkNavigation.OrderDateCompleted >= May && obj.OrderIdFkNavigation.OrderDateCompleted <= May1)
                {
                    MaySales += (obj.MenuItemIdFkNavigation.MenuItemPrice * obj.ItemQty);
                }
                else if (obj.OrderIdFkNavigation.OrderDateCompleted >= June && obj.OrderIdFkNavigation.OrderDateCompleted <= June1)
                {
                    JuneSales += (obj.MenuItemIdFkNavigation.MenuItemPrice * obj.ItemQty);
                }
                else if (obj.OrderIdFkNavigation.OrderDateCompleted >= July && obj.OrderIdFkNavigation.OrderDateCompleted <= July1)
                {
                    JulySales += (obj.MenuItemIdFkNavigation.MenuItemPrice * obj.ItemQty);

                }
                else if (obj.OrderIdFkNavigation.OrderDateCompleted >= Aug && obj.OrderIdFkNavigation.OrderDateCompleted <= Aug1)
                {
                    AugSales += (obj.MenuItemIdFkNavigation.MenuItemPrice * obj.ItemQty);
                }
                else if (obj.OrderIdFkNavigation.OrderDateCompleted >= Sep && obj.OrderIdFkNavigation.OrderDateCompleted <= Sep1)
                {
                    SepSales += (obj.MenuItemIdFkNavigation.MenuItemPrice * obj.ItemQty);
                }
                else if (obj.OrderIdFkNavigation.OrderDateCompleted >= Oct && obj.OrderIdFkNavigation.OrderDateCompleted <= Oct1)
                {
                    OctSales += (obj.MenuItemIdFkNavigation.MenuItemPrice * obj.ItemQty);
                }
                else if (obj.OrderIdFkNavigation.OrderDateCompleted >= Nov && obj.OrderIdFkNavigation.OrderDateCompleted <= Nov1)
                {
                    NovSales += (obj.MenuItemIdFkNavigation.MenuItemPrice * obj.ItemQty);
                }
                else
                {
                    DecSales += (obj.MenuItemIdFkNavigation.MenuItemPrice * obj.ItemQty);
                }
            }
            dynamic MonthlySales1 = new ExpandoObject();
            MonthlySales1.Month = "January";
            MonthlySales1.Sales = janSales;
            list.Add(MonthlySales1);

            dynamic MonthlySales2 = new ExpandoObject();
            MonthlySales2.Month = "February";
            MonthlySales2.Sales = FebSales;
            list.Add(MonthlySales2);

            dynamic MonthlySales3 = new ExpandoObject();
            MonthlySales3.Month = "March";
            MonthlySales3.Sales = MarchSales;
            list.Add(MonthlySales3);

            dynamic MonthlySales4 = new ExpandoObject();
            MonthlySales4.Month = "April";
            MonthlySales4.Sales = AprilSales;
            list.Add(MonthlySales4);

            dynamic MonthlySales5 = new ExpandoObject();
            MonthlySales5.Month = "May";
            MonthlySales5.Sales = MaySales;
            list.Add(MonthlySales5);

            dynamic MonthlySales6 = new ExpandoObject();
            MonthlySales6.Month = "June";
            MonthlySales6.Sales = JuneSales;
            list.Add(MonthlySales6);

            dynamic MonthlySales7 = new ExpandoObject();
            MonthlySales7.Month = "July";
            MonthlySales7.Sales = JulySales;
            list.Add(MonthlySales7);

            dynamic MonthlySales8 = new ExpandoObject();
            MonthlySales8.Month = "August";
            MonthlySales8.Sales = AugSales;
            list.Add(MonthlySales8);

            dynamic MonthlySales9 = new ExpandoObject();
            MonthlySales9.Month = "September";
            MonthlySales9.Sales = SepSales;
            list.Add(MonthlySales9);

            dynamic MonthlySales10 = new ExpandoObject();
            MonthlySales10.Month = "October";
            MonthlySales10.Sales = OctSales;
            list.Add(MonthlySales10);

            dynamic MonthlySales11 = new ExpandoObject();
            MonthlySales11.Month = "November";
            MonthlySales11.Sales = NovSales;
            list.Add(MonthlySales11);

            dynamic MonthlySales12 = new ExpandoObject();
            MonthlySales12.Month = "December";
            MonthlySales12.Sales = DecSales;
            list.Add(MonthlySales12);


            return list;
        }
    }
}
