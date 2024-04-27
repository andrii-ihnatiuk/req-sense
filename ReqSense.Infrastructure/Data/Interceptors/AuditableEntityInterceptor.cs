using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ReqSense.Application.Common.Interfaces;
using ReqSense.Domain.Common;

namespace ReqSense.Infrastructure.Data.Interceptors;

public class AuditableEntityInterceptor(ICurrentUser currentUser) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        SetAuditableProperties(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        SetAuditableProperties(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void SetAuditableProperties(DbContext? context)
    {
        if (context is null)
        {
            return;
        }

        var now = DateTimeOffset.Now;
        foreach (var entry in context.ChangeTracker.Entries<AuditableEntityBase>())
        {
            if (entry.State is EntityState.Added)
            {
                entry.Entity.Created = now;
                entry.Entity.CreatedBy = currentUser.Id;
            }

            else if (entry.State is EntityState.Modified)
            {
                entry.Entity.LastModified = now;
                entry.Entity.LastModifiedBy = currentUser.Id;
            }
        }
    }
}