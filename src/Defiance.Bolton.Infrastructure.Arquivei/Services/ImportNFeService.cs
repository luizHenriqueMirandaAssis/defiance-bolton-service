using Defiance.Bolton.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Defiance.Bolton.Infrastructure.Arquivei.Helpers;
using Flurl.Http;
using Defiance.Bolton.Infrastructure.Arquivei.Contracts;
using System.Linq;
using Defiance.Bolton.Domain.Entities;
using Defiance.Bolton.Domain.Interfaces.Services;

namespace Defiance.Bolton.Infrastructure.Arquivei.Handlers
{
    public class ImportNFeService : IImportFileService
    {
        private readonly IConfiguration _configuration;
        private readonly IImportHistoryRepository _importHistoryRepository;
        private readonly IEletronicTaxInvoiceAppService _eletronicTaxInvoiceAppService;
        private readonly IImportHistoryAppService _importHistoryAppService;

        public ImportNFeService(
            IConfiguration configuration,
            IImportHistoryRepository importHistoryRepository,
            IEletronicTaxInvoiceAppService eletronicTaxInvoiceAppService,
            IImportHistoryAppService importHistoryAppService
           )
        {
            _configuration = configuration;
            _eletronicTaxInvoiceAppService = eletronicTaxInvoiceAppService;
            _importHistoryAppService = importHistoryAppService;
            _importHistoryRepository = importHistoryRepository;
        }

        public async Task<bool> Import()
        {
            var result = ResponseContract.Empty();

            do
            {
                var newHistory = ImportHistory.NewInstance();
                var history = await _importHistoryRepository.GetLastExecutionAsync();

                result = await GetNFe(history);

                if (!result.Data.Any())
                    return true;

                await ImportResponse(result);
                await _importHistoryAppService.AddAsync(newHistory.SetCurrentPage(result.Page.Next));

            } while (result.Data.Any());

            return true;
        }

        private async Task<ResponseContract> GetNFe(ImportHistory history)
        {
            var integrationHelper = IntegrationHelper.Build(_configuration["Arquivei:Uri"], _configuration["Arquivei:EndPointNFe"]);

            var result = await integrationHelper.GetFullUri(history)
                                             .WithHeader("x-api-id", _configuration["Arquivei:ApiId"])
                                             .WithHeader("x-api-key", _configuration["Arquivei:ApiKey"])
                                             .WithHeader("Content-Type", "application/json")
                                             .AllowHttpStatus("2XX")
                                             .GetJsonAsync<ResponseContract>();

            return result;
        }

        private async Task ImportResponse(ResponseContract result)
        {
            if (result is null)
                throw new ArgumentNullException(nameof(result));

            var allNfes = EletronicTaxInvoice.ListEmpty();

            result.Data.ForEach(x => allNfes.Add(x.Xml.FromBase64()));

            await _eletronicTaxInvoiceAppService.AddAllAsync(allNfes);
        }
    }
}
