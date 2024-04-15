using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AggregateRootEventTriggeringBug.Data;
using Volo.Abp.DependencyInjection;

namespace AggregateRootEventTriggeringBug.EntityFrameworkCore;

public class EntityFrameworkCoreAggregateRootEventTriggeringBugDbSchemaMigrator
    : IAggregateRootEventTriggeringBugDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAggregateRootEventTriggeringBugDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the AggregateRootEventTriggeringBugDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AggregateRootEventTriggeringBugDbContext>()
            .Database
            .MigrateAsync();
    }
}
