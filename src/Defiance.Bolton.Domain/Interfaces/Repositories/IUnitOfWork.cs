using System.Threading.Tasks;

namespace Defiance.Bolton.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
