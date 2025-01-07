using Vanguardium.ApplicationService.Interfaces;
using Vanguardium.ApplicationService.Mappers;

namespace Vanguardium.IoC.InversionHandlers;

public static class MapperModule
{
    public static IServiceCollection AddMappers(this IServiceCollection serviceCollection) =>
        serviceCollection.AddScoped<IUserMapper, UserMapper>()
            .AddScoped<ITransferMapper, TransferMapper>();

}   