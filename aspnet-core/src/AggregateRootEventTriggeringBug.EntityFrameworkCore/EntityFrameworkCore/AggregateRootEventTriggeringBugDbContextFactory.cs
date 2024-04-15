using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AggregateRootEventTriggeringBug.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AggregateRootEventTriggeringBugDbContextFactory : IDesignTimeDbContextFactory<AggregateRootEventTriggeringBugDbContext>
{
    public AggregateRootEventTriggeringBugDbContext CreateDbContext(string[] args)
    {
        AggregateRootEventTriggeringBugEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AggregateRootEventTriggeringBugDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new AggregateRootEventTriggeringBugDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AggregateRootEventTriggeringBug.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
