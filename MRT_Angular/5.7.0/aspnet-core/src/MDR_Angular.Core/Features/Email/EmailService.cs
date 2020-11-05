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
            string message, 
            params Attatchment[] attatchments)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(fromDisplayName, fromEmailAddress));
            email.To.Add(new MailboxAddress(toName, toEmailAddress));
            email.Subject = subject;

            var body = new BodyBuilder
            {
                HtmlBody = message
            };
            foreach( var attachment in attatchments)
            {
                using ( var stream = await attachment.ContentToStreamAsync())
                {
                    body.Attachments.Add(attachment.FileName, stream);
                }

               
            }


            using(var client = new SmtpClient()){
                client.ServerCertificateValidationCallback = (sender,
                    Certificate,
                    certChainTpe,
                    errors) => true;
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                await client.ConnectAsync("smpt.host", 587, false).ConfigureAwait(false);
                await client.AuthenticateAsync("username", "password").ConfigureAwait(false);


                await client.SendAsync(email).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);


            }
        }
    }
}
