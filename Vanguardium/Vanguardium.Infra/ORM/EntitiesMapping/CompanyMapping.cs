using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vanguardium.Domain.Entities;
using Vanguardium.Infra.ORM.EntitiesMapping.Base;

namespace Vanguardium.Infra.ORM.EntitiesMapping;

public class CompanyMapping : BaseMapping, IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable(nameof(Company), Schema);
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(a => a.CorporateName)
            .HasColumnType("varchar(150)")
            .HasColumnName("corporateName")
            .IsUnicode()
            .HasColumnOrder(2);

        builder.Property(a => a.Document)
            .HasColumnType("varchar(50)")
            .HasColumnName("document")
            .HasColumnOrder(3)
            .IsRequired();

        builder.HasOne(c => c.Address)
            .WithOne()
            .HasForeignKey<Company>(c => c.AddressId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.Property(a => a.ContactNumber)
            .HasColumnType("varchar(50)")
            .HasColumnName("contactNumber")
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(c => c.Balance)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("balance")
            .HasColumnOrder(5)
            .IsRequired();
    }
}