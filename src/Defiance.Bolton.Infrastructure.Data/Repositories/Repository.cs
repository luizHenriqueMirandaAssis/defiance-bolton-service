using Defiance.Bolton.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Defiance.Bolton.Infrastructure.Data.Repositories
{
    public class Repository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        protected readonly TDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(TDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
