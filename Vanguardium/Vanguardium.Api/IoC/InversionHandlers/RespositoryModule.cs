using Vanguardium.Infra.Interfaces;
using Vanguardium.Infra.Repository;

namespace Vanguardium.IoC.InversionHandlers;

public static class RespositoryModule
{
    public static IServiceCollection AddRepository(this IServiceCollection serviceCollection) =>
        serviceCollection.AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ITransferRepository, TransferRepository>();
}