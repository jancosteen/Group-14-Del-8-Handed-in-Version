using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.Authorization.Users;
using MDR_Angular.Features.Email;
using MDR_Angular.OrderMate.Reservations.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MDR_Angular.OrderMate.Reservations
{
    //[AbpAuthorize(PermissionNames.Pages_R)]
    public class ReservationAppService : AsyncCrudAppService<
        Reservation, ReservationDto, int, PagedAndSortedResultRequestDto, ReservationDto>, IReservationAppService
    {

        private readonly IEmail _email;
        private readonly UserManager _userManager;
        public ReservationAppService(IRepository<Reservation> repository,
             IEmail email,
            UserManager userManager) : base(repository) {

            _email = email;
            _userManager = userManager;

        }

        public async Task<bool> SendEmail(SmsDto input)
        {
            var user = await _userManager.GetUserByIdAsync(input.userId);



            if (user != null)
            {
                var message = "<h1> Hello " + user.FullName + "</h1><br><h3>Your reservation at " + input.restaurantName + " for the date of " + input.reservationDateReserved + " has been set. Your reservation status is: " + input.reservationStatus + "</h3>";



                await _email.SendEmailAsync("OrderMate", "ordermate370@gmail.com", user.FullName, user.EmailAddress, "Reservation", message);

            }
            return true;
        }


        public void SendMessage(SmsDto input)
        {
            string accountSid = "AC02a9302269d79b74edb6873f32138fa4";
            string authToken = "83aff9bfd42384a16a57ef87487103ef";



            TwilioClient.Init(accountSid, authToken);
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
            var from = new PhoneNumber("+12056513180");


            //enter the number your sending
            var to = new PhoneNumber("+27828330426");


            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Your reservation at " + input.restaurantName + " for the date of " + input.reservationDateReserved + " has been set. Your reservation status is: " + input.reservationStatus

            );

            Console.WriteLine(message.Sid);
        }

        public ListResultDto<ReservationDto> GetReservationById(int id)
        {
            var reservation = Repository
                .GetAll().Where(x => x.Id == id)
                .Include(i => i.UserIdFkNavigation)
                .Include(i => i.RestaurantIdFkNavigation)
                .Include(i => i.ReservationStatusIdFkNavigation)
                .Include(i => i.Seating)
                

                .ToList();
            return new ListResultDto<ReservationDto>(ObjectMapper.Map<List<ReservationDto>>(reservation));
        }

        public ListResultDto<ReservationDto> GetReservationByUserId(int id)
        {
            var reservation = Repository
                .GetAll().Where(x => x.UserIdFk == id)
                .Include(i => i.UserIdFkNavigation)
                .Include(i => i.RestaurantIdFkNavigation)
                .Include(i => i.ReservationStatusIdFkNavigation)
                .Include(i => i.Seating)


                .ToList();
            return new ListResultDto<ReservationDto>(ObjectMapper.Map<List<ReservationDto>>(reservation));
        }

        protected override IQueryable<Reservation> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                //.Include(i => i.ReservationRestaurant).ThenInclude(x => x.RestaurantIdFkNavigation)
                .Include(i => i.ReservationStatusIdFkNavigation)
                .Include(i => i.Seating)
                .Include(i => i.UserIdFkNavigation)
                .Include(i => i.RestaurantIdFkNavigation);
        }

        
    }
}
