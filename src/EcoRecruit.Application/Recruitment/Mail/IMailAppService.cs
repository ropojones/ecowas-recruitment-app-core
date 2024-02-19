using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EcoRecruit.Recruitment.Applicants.Dto;
using EcoRecruit.Recruitment.Mail;
using System.Threading.Tasks;

namespace EcoRecruit.Recruitment.Applicants
{
    public interface IMailService : IApplicationService
    {
        Task< bool>SendMailAsync(MailData message);      

    
    }
}
