using Defiance.Bolton.Domain.Entities;
using System.Threading.Tasks;

namespace Defiance.Bolton.Domain.Interfaces.Services
{
    public interface IImportHistoryAppService
    {
        Task AddAsync(ImportHistory importHistory);
    }
}
