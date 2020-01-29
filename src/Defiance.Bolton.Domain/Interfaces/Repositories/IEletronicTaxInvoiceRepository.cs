using Defiance.Bolton.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Defiance.Bolton.Domain.Interfaces.Repositories
{
    public interface IEletronicTaxInvoiceRepository
    {
        Task<List<EletronicTaxInvoice>> GetAllByKeysAsync(List<string> keys);
        Task AddAllAsync(List<EletronicTaxInvoice> eletronicTaxInvoices);
        Task<EletronicTaxInvoice> GetByKeyAsync(string key);
    }
}
