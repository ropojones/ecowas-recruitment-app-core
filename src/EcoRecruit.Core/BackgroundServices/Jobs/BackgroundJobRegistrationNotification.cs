using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRecruit.Core.BackgroundServices
{
    public class BackgroundJobRegistrationNotification : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return null;
        }
    }
}
