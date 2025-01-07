using Vanguardium.Domain.Entities;

namespace Vanguardium.Infra.Interfaces;

public interface ITransferRepository
{
    Task<bool> SaveAsync(Transfers transfers);

    Task<bool> UpdateAsync(Transfers transfers);

    Task<List<Transfers>> GetAllAsync();
}