using Domain.Shareds.Entities;
using System.Linq.Expressions;

namespace Domain.Shareds.Repositories
{
    public interface IRepositoryBase<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        Task<IQueryable<TEntity>> GetQueryableAsync();
        Task<TEntity?> GetAsync(TKey key, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? expression = null, CancellationToken cancellationToken = default);
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
