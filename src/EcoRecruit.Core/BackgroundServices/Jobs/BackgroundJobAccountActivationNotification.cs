using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRecruit.BackgroundServices.Jobs
{
    public class BackgroundJobAccountActivationNotification : IJob
    {

        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Background job executed by " + DateTime.UtcNow.ToString());
            return Task.CompletedTask;
        }
    }
}
