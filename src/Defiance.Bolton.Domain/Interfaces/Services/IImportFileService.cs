using System.Threading.Tasks;

namespace Defiance.Bolton.Domain.Interfaces.Services
{
    public interface IImportFileService
    {
        Task<bool> Import();
    }
}
