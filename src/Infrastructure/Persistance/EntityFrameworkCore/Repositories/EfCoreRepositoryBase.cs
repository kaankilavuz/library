using Domain.Shareds.Entities;
using Domain.Shareds.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistance.EntityFrameworkCore.Repositories
{
    public abstract class EfCoreRepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        protected LibraryDbContext Context { get; }
        private DbSet<TEntity> DbSet { get; }

        protected EfCoreRepositoryBase(LibraryDbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public async Task<TEntity?> GetAsync(TKey key, CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(key, cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? expression = null, CancellationToken cancellationToken = default)
        {
            var query = DbSet.AsQueryable()
                .AsNoTracking();

            if (expression == null)
                return await query.ToListAsync(cancellationToken);

            return await query.Where(expression)
                .ToListAsync(cancellationToken);
        }

        public Task<IQueryable<TEntity>> GetQueryableAsync()
        {
            return Task.Run(() => DbSet.AsQueryable());
        }

        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var result = await DbSet.AddAsync(entity, cancellationToken);
            Console.WriteLine(Context.Entry(result.Entity).State);
            Console.WriteLine("Context id: " + Context.ContextId);
            return result.Entity;
        }
    }
}
