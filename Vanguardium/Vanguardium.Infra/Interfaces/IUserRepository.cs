using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Vanguardium.Domain.Entities;

namespace Vanguardium.Infra.Interfaces;

public interface IUserRepository
{
    Task<bool> SaveAsync(User user);

    Task<bool> UpdateAsync(User user);

    Task<List<User>> GetAllAsync();

    Task<User?> FindByPredicateAsync(Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        bool toQuery = false);
}