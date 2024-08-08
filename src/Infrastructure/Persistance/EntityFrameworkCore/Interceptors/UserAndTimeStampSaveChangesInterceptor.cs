using Domain.Shareds.Constants;
using Domain.Shareds.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Persistance.EntityFrameworkCore.Interceptors
{
    public class UserAndTimeStampSaveChangesInterceptor : SaveChangesInterceptor
    {

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;

            if(context is null)
                throw new ArgumentNullException(nameof(eventData.Context));

            var entries = context!.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                var entity = entry.Entity;

                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entity.GetType().IsGenericType && entity.GetType().GetGenericTypeDefinition() == typeof(CreationAuditedEntity<>))
                        {
                            entity.GetType().GetProperty(AuditConsts.CreationTime)!.SetValue(entity, DateTime.UtcNow);
                            entity.GetType().GetProperty(AuditConsts.CreatorId)!.SetValue(entity, null);
                        }
                        break;
                    case EntityState.Modified:
                        break;
                    case EntityState.Deleted:
                        break;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
