using Vanguardium.Domain.Handlers.PaginationHandler;

namespace Vanguardium.Infra.Interfaces;

public interface IPaginationQueryService<T> where T : class
{
    Task<PageList<T>> CreatePaginationAsync(IQueryable<T> source, int pageSize, int pageNumber);

    PageList<T> CreatePagination(List<T> source, int pageSize, int pageNumber);
}