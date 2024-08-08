using Domain.Shareds.Uow;

namespace Persistance.EntityFrameworkCore.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        protected LibraryDbContext Context { get; }

        public UnitOfWork(LibraryDbContext context)
        {
            Context = context;
        }

        public ValueTask DisposeAsync()
        {
            return Context.DisposeAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
