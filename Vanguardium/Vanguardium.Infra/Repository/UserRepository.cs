using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Vanguardium.Domain.Entities;
using Vanguardium.Infra.Interfaces;
using Vanguardium.Infra.ORM.Context;
using Vanguardium.Infra.Repository.Base;

namespace Vanguardium.Infra.Repository;

public sealed class UserRepository(
    ApplicationContext applicationContext
    ) : BaseRepository<User>(applicationContext), IUserRepository
{
    public async Task<bool> SaveAsync(User user)
    {
        await DbSetContext.AddAsync(user);

        return await SaveInDataBase();
    }

    public async Task<bool> UpdateAsync(User user)
    {
        DbSetContext.Update(user);

        return await SaveInDataBase();
    }

    public async Task<List<User>> GetAllAsync()
    {
        IQueryable<User> query = DbSetContext;

        query = query.AsNoTracking();


        return await query.ToListAsync();
    }

    public async Task<User?> FindByPredicateAsync(Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null, 
        bool toQuery = false)
    {
       
        IQueryable<User> query = DbSetContext;

        if (toQuery)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(predicate);
    }
}