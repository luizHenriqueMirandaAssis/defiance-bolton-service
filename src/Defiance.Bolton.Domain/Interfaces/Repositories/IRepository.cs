using System;

namespace Defiance.Bolton.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
    }
}
