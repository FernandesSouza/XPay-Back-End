using Microsoft.EntityFrameworkCore;

namespace Vanguardium.Infra.ORM.Context
{
    public sealed class ApplicationContext(
        DbContextOptions<ApplicationContext> dbContext)
        : DbContext(dbContext)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}