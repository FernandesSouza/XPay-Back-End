using Vanguardium.Settings.Handlers;

namespace Vanguardium.Settings;

public static class SettingsControl
{
    public static void AddSettingsControl(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseConnectionSettings();
        services.AddProviderSettings(configuration);
    }
}