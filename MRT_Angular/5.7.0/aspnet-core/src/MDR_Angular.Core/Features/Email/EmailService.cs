using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDR_Angular.Features.Email
{
    public class EmailService : IEmail
    {
        public async Task SendEmailAsync(string fromDisplayName, 
            string fromEmailAddress, 
            string toName, 
            string toEmailAddress, 
            string subject, 
            string message
            )
        {
            var email = new MimeMessage();
            
            email.From.Add(new MailboxAddress(fromDisplayName, fromEmailAddress));
            email.To.Add(new MailboxAddress(toName, toEmailAddress));
            email.Subject = subject;

            

            var tail = "<br/><br/>For more information or if you have any problems please email us here: ordermate370@gmail.com";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = message + tail;



            email.Body = bodyBuilder.ToMessageBody();




            using (var client = new SmtpClient()){
                client.ServerCertificateValidationCallback = (sender,
                    Certificate,
                    certChainTpe,
                    errors) => true;
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                await client.ConnectAsync("smtp.gmail.com", 587, false).ConfigureAwait(false);
                await client.AuthenticateAsync("ordermate370@gmail.com", "Inf370mate").ConfigureAwait(false);


                await client.SendAsync(email).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);


            }
        }
    }
}
