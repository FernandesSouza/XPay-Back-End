using Microsoft.EntityFrameworkCore;
using Vanguardium.Domain.Handlers.PaginationHandler;
using Vanguardium.Infra.Interfaces;

namespace Vanguardium.Infra.Service;

public sealed class PaginationQueryService<T> : IPaginationQueryService<T> where T : class
{
    public async Task<PageList<T>> CreatePaginationAsync(IQueryable<T> source, int pageSize, int pageNumber)
    {
        var count = await source.CountAsync();
        var itens = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        return new PageList<T>(itens, count, pageNumber, pageSize);
    }

    public PageList<T> CreatePagination(List<T> source, int pageSize, int pageNumber)
    {
        var count = source.Count;
        var itens = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return new PageList<T>(itens, count, pageNumber, pageSize);
    }
}   