using Hangfire;

namespace Defiance.Bolton.Presentation.API.Tasks.Interfaces
{
    [DisableConcurrentExecution(90)]
    [AutomaticRetry(Attempts = 10, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
    [Queue("integration")]
    public interface IIntegrationTask
    {
        void Run();
    }
}
