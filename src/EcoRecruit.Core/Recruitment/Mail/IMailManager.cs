using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Mail
{
    public interface IMailManager
    {
      Task<bool> SendMailAsync(MailData mailData);
    }
}
