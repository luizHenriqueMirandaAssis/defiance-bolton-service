using Defiance.Bolton.Application.Services;
using Defiance.Bolton.Domain.Interfaces.Services;
using Defiance.Bolton.Infrastructure.Arquivei.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Defiance.Bolton.Infrastructure.Ioc
{
    public class ApplicationRegister
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IEletronicTaxInvoiceAppService, EletronicTaxInvoiceAppService>();
            services.AddTransient<IImportHistoryAppService, ImportHistoryAppService>();
            services.AddTransient<IImportFileService, ImportNFeService>();
        }
    }
}
