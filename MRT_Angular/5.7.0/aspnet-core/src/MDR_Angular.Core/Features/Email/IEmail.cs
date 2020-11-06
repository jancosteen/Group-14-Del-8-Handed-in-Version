using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDR_Angular.Features.Email
{
    public interface IEmail
    {
        Task SendEmailAsync(
            string fromDisplayName,
            string fromEmailAddress,
            string toName,
            string toEmailAddress,
            string subject,
            string message
            );
    }
}
