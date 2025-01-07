using Microsoft.EntityFrameworkCore;
using Vanguardium.Domain.Entities;
using Vanguardium.Infra.Interfaces;
using Vanguardium.Infra.ORM.Context;
using Vanguardium.Infra.Repository.Base;

namespace Vanguardium.Infra.Repository;

public sealed class TransferRepository(
    ApplicationContext applicationContext
) : BaseRepository<Transfers>(applicationContext), ITransferRepository
{
    public async Task<bool> SaveAsync(Transfers transfers)
    {
        await DbSetContext.AddAsync(transfers);

        return await SaveInDataBase();
    }

    public async Task<bool> UpdateAsync(Transfers transfers)
    {
        DbSetContext.Update(transfers);

        return await SaveInDataBase();
    }

    public async Task<List<Transfers>> GetAllAsync()
    {
        IQueryable<Transfers> query = DbSetContext;

        query = query.AsNoTracking();


        return await query.ToListAsync();
    }
}