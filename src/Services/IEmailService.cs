using System.Collections.Generic;
using System.Threading.Tasks;
using MimeKit;

namespace www.veinid365.cn.Services
{
    public interface IEmailService
    {
        Task SendAsync(string toName, string toEmail, string subject, string body);
        Task SendRangeAsync(IEnumerable<MailboxAddress> addresses, string subject, string body);
    }
}