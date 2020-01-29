using Defiance.Bolton.Domain.Interfaces.Repositories;
using Defiance.Bolton.Infrastructure.Data.Context;
using System.Threading.Tasks;

namespace Defiance.Bolton.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefianceBoltonContext _context;

        public UnitOfWork(DefianceBoltonContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
