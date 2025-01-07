using Microsoft.EntityFrameworkCore;
using Vanguardium.Infra.ORM.Context;

namespace Vanguardium.Infra.Repository.Base;

public abstract class BaseRepository<T>(
    ApplicationContext context) : IDisposable where T : class
{
    private const int StandardQuantity = 0;

    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }

    protected DbSet<T> DbSetContext => context.Set<T>();

    public async Task<bool> SaveInDataBase(CancellationToken cancellationToken = default) =>
        await context.SaveChangesAsync(cancellationToken) > StandardQuantity;
}