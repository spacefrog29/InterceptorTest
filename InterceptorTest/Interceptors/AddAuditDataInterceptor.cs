using InterceptorTest.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorTest.Interceptors
{
    public class AddAuditDataInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var changeTracker = eventData.Context.ChangeTracker;
            var addedList = changeTracker.Entries<IAuditable>().Where(x=>x.State == Microsoft.EntityFrameworkCore.EntityState.Added).ToList();
            foreach (var entityEntry in addedList)
            {
                entityEntry.Property(x=>x.CreatedDate).CurrentValue = DateTime.Now;
            }

            var modifiedList = changeTracker.Entries<IAuditable>().Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Modified).ToList();
            foreach (var entityEntry in modifiedList)
            { 
            entityEntry.Property(x=>x.LastModifiedDate).CurrentValue = DateTime.Now;
            }
            return base.SavingChanges(eventData, result);
        }    
    }
}
