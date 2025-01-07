using Microsoft.EntityFrameworkCore.Infrastructure;
using Vanguardium.Domain.Interface;
using Vanguardium.Infra.ORM.Context;

namespace Vanguardium.Infra.ORM.Uow;

//FALTA FAZER INVERSÃO DE CONTROLE
public sealed class UnitOfWork(
    ApplicationContext applicationContext)
    : IUnitOfWork
{
    private readonly DatabaseFacade _databaseFacade = applicationContext.Database;

    public void CommitTransaction()
    {
        try
        {
            _databaseFacade.CommitTransaction();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
    }

    public void RollbackTransaction() => _databaseFacade.RollbackTransaction();

    public void BeginTransaction() => _databaseFacade.BeginTransaction();
}