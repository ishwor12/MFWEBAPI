using IdentityCommon.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityCommon.Interface
{
    public interface IEmailSender
    {
        Task<DataResult> SendEmailAsync(string toEmail, string subject, string message, string name = null);
    }
}
