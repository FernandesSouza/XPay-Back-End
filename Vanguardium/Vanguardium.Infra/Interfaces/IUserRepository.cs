using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Vanguardium.Domain.Entities;
using Vanguardium.Domain.Handlers.PaginationHandler;
using Vanguardium.Domain.Handlers.PaginationHandler.Filters;

namespace Vanguardium.Infra.Interfaces;

public interface IUserRepository
{
    Task<bool> SaveAsync(User user);

    Task<bool> UpdateAsync(User user);

    Task<List<User>> GetAllAsync();

    Task<User?> FindByPredicateAsync(Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        bool toQuery = false);

    Task<PageList<User>> FindAllWithPaginationAsync(UserFilter pageParams,
        Expression<Func<User, bool>>? predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null);
}