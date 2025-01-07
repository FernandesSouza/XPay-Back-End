using Vanguardium.ApplicationService.Interfaces;
using Vanguardium.ApplicationService.RabbitMqServices;
using Vanguardium.ApplicationService.Service;

namespace Vanguardium.IoC.InversionHandlers;

public static class ServiceModule
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection) =>
        serviceCollection.AddScoped<IUserCommandService, UserCommandService>()
            .AddScoped<IUserQueryService, UserQueryService>()
            .AddScoped<ICreatingProducers, CreatingProducers>();
}