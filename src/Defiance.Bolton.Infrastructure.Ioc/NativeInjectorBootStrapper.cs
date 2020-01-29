using Microsoft.Extensions.DependencyInjection;

namespace Defiance.Bolton.Infrastructure.Ioc
{
    public  class NativeInjectorBootStrapper
    {
        public static void AddIoC(IServiceCollection services)
        {
            InfraRegister.RegisterServices(services);
            ApplicationRegister.RegisterServices(services);
        }
    }
}
