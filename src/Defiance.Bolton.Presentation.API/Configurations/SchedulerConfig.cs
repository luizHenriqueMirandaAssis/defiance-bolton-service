using Defiance.Bolton.Presentation.API.Tasks.Interfaces;
using Hangfire;

namespace Defiance.Bolton.Presentation.API.Configurations
{
    public class SchedulerConfig
    {
        public void RunTasks()
        {
            RecurringJob.AddOrUpdate<IIntegrationTask>("IntegrationTask",
                     task => task.Run(), Cron.Daily(01));
        }
    }
}
