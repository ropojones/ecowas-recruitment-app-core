using Abp.Domain.Entities;

namespace EcoRecruit.Recruitment.Applicants
{
    public class ApplicantCustom: Entity<long>
    {

  public string CustomInfo { get; set; }
        public long ApplicantId { get; set; }
        public Applicant Applicant {get;set;}

    }
}