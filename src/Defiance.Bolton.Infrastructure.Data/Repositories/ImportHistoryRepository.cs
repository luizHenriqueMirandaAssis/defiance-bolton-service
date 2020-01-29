using Defiance.Bolton.Domain.Entities;
using Defiance.Bolton.Domain.Interfaces.Repositories;
using Defiance.Bolton.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Defiance.Bolton.Infrastructure.Data.Repositories
{
    public class ImportHistoryRepository : Repository<ImportHistory, DefianceBoltonContext>, IImportHistoryRepository
    {
        public ImportHistoryRepository(DefianceBoltonContext context) : base(context) { }

        public async Task<ImportHistory> GetLastExecutionAsync()
        {
            return await DbSet.OrderByDescending(x => x.DateCreated).FirstOrDefaultAsync();
        }
        public async Task<ImportHistory> GetById(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.ImportHistoryId.Equals(id));
        }
        public async Task AddAsync(ImportHistory importHistory)
        {
            await DbSet.AddAsync(importHistory);
        }
        public async Task UpdateAsync(ImportHistory importHistory)
        {
            var current = await GetById(importHistory.ImportHistoryId);
            Db.Entry(current).CurrentValues.SetValues(importHistory);
        }
    }
}
