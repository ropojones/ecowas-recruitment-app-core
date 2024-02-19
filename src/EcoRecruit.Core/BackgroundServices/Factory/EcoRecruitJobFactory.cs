using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRecruit.BackgroundServices.Factory
{
    public class EcoRecruitJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public EcoRecruitJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        { 
            try
            {
                return _serviceProvider.GetService(bundle.JobDetail.JobType) as IJob;
            }
            catch (Exception ex)
            {
                throw new SchedulerException(string.Format("Problem while instantiating job '{0}' from the EcoRecruit IOC", bundle.JobDetail.Key));
            }
           
        }

        public void ReturnJob(IJob job)
        {
            var disposable = job as IDisposable;
            disposable?.Dispose();
        }
    }
}
