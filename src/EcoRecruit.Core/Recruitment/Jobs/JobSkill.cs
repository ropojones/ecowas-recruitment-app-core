using Abp.Domain.Entities;

namespace EcoRecruit.Recruitment.Jobs
{
    public class JobSkill : Entity<long>
    {

        public string Skill { get; set; }
        public string  Country {get;set;}

        public int CheckId {  get; set;}    


        public int JobId { get; set; }
        public Job Job { get; set; }
      
    }
}