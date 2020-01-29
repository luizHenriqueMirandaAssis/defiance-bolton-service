using Defiance.Bolton.Domain.Aggregates;
using Defiance.Bolton.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Defiance.Bolton.Domain.Interfaces.Services
{
    public interface IEletronicTaxInvoiceAppService
    {
        Task AddAllAsync(List<EletronicTaxInvoice> eletronicTaxInvoices);
        Task<NFe> GetByAccessKeyAsync(string accessKey);
    }
}
