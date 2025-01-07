using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Vanguardium.Infra.ORM.Context;

public sealed class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        var connectionString =
            "Data Source=(local)\\SQLEXPRESS;Initial Catalog=Vanguardium_Finance;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=True;Pooling=True;Min Pool Size=10;Max Pool Size=100;";

        optionsBuilder.UseSqlServer(connectionString);

        return new ApplicationContext(optionsBuilder.Options);
    }
}