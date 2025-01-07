using Microsoft.EntityFrameworkCore;
using Vanguardium.Domain.Providers;
using Vanguardium.Infra.ORM.Context;

namespace Vanguardium.Settings.Handlers;

public static class DatabaseConnectionSettings
{
    public static void AddDatabaseConnectionSettings(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>((serviceProv, options) =>
            options.UseSqlServer(
                serviceProv.GetRequiredService<ConnectionStringOptions>().DefaultConnection,
                sql => sql.CommandTimeout(180)));
    }
}