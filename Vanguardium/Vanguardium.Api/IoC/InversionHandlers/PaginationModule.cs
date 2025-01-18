using Vanguardium.Domain.Entities;
using Vanguardium.Infra.Interfaces;
using Vanguardium.Infra.Service;

namespace Vanguardium.IoC.InversionHandlers;

public static class PaginationModule
{
    public static IServiceCollection AddPagination(this IServiceCollection services) =>
        services.AddScoped<IPaginationQueryService<User>, PaginationQueryService<User>>()
            .AddScoped<IPaginationQueryService<Transfers>, PaginationQueryService<Transfers>>();
}