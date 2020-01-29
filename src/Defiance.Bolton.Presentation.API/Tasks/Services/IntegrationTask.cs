using Defiance.Bolton.Domain.Interfaces.Services;
using Defiance.Bolton.Presentation.API.Tasks.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Defiance.Bolton.Presentation.API.Tasks.Services
{
    public class IntegrationTask : IIntegrationTask
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public IntegrationTask(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async void Run()
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var _importFIleService = scope.ServiceProvider.GetService<IImportFileService>();
                    await _importFIleService.Import();
                }
            }
            catch (Exception ex)
           {
                //TODO: Add log
            }
        }
    }
}
