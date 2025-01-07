using Microsoft.EntityFrameworkCore;
using Vanguardium.Infra.ORM.Context;

namespace Vanguardium.Settings.Handlers;

public static class MigrationHandlerSettings
{
    public static async Task MigrateDatabase(this WebApplication webApp)
    {
        using var scope = webApp.Services.CreateScope();
        await using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

        await appContext.Database.MigrateAsync();
    }
}