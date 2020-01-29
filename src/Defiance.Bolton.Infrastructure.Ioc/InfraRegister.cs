using Defiance.Bolton.Domain.Interfaces.Repositories;
using Defiance.Bolton.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Defiance.Bolton.Infrastructure.Ioc
{
    public class InfraRegister
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEletronicTaxInvoiceRepository, EletronicTaxInvoiceRepository>();
            services.AddScoped<IImportHistoryRepository, ImportHistoryRepository>();
    
        }
    }
}
