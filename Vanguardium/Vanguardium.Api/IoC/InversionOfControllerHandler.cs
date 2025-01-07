using Vanguardium.Domain.Interface;
using Vanguardium.Infra.ORM.Context;
using Vanguardium.Infra.ORM.Uow;
using Vanguardium.IoC.InversionHandlers;

namespace Vanguardium.IoC;

public static class InversionOfControllerHandler
{
    public static void AddInversionControllerHandler(this IServiceCollection serviceCollection) =>
        serviceCollection.AddScoped<ApplicationContext>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddServices()
            .AddRepository()
            .AddMappers();
}