using Defiance.Bolton.Domain.Entities;
using Defiance.Bolton.Domain.Interfaces.Repositories;
using Defiance.Bolton.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Defiance.Bolton.Infrastructure.Data.Repositories
{
    public class EletronicTaxInvoiceRepository : Repository<EletronicTaxInvoice, DefianceBoltonContext>, IEletronicTaxInvoiceRepository
    {
        public EletronicTaxInvoiceRepository(DefianceBoltonContext context) : base(context) { }

        public async Task AddAllAsync(List<EletronicTaxInvoice> eletronicTaxInvoices)
        {
            await DbSet.AddRangeAsync(eletronicTaxInvoices);
        }
        public async Task<List<EletronicTaxInvoice>> GetAllByKeysAsync(List<string> keys)
        {
            return await DbSet.Where(x => keys.Contains(x.AccessKey)).ToListAsync();
        }

        public async Task<EletronicTaxInvoice> GetByKeyAsync(string key)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.AccessKey.Equals(key));
        }
    }
}
