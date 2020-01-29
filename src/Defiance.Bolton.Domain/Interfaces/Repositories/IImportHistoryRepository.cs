using Defiance.Bolton.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Defiance.Bolton.Domain.Interfaces.Repositories
{
    public interface IImportHistoryRepository
    {
        Task<ImportHistory> GetById(Guid id);
        Task<ImportHistory> GetLastExecutionAsync();
        Task AddAsync(ImportHistory importHistory);
        Task UpdateAsync(ImportHistory importHistory);
    }
}
