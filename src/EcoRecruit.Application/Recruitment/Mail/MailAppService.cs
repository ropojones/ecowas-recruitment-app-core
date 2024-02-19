using Abp.Application.Services;
using EcoRecruit.Recruitment.Mail;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants
{

    public class MailService : ApplicationService, IMailService
    {
        private readonly IMailManager _mailManager;
        public readonly MailSettings _mailSettings;

        public MailService(IMailManager mailManager, MailSettings mailSettings)
        {
            _mailManager = mailManager;  
            _mailSettings = mailSettings;    
        }

        public async Task<bool> SendMailAsync(MailData mailData)
        {
             await _mailManager.SendMailAsync(mailData);
                return true;
          
        }
    }
}
