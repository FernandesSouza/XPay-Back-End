using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vanguardium.Domain.Entities;
using Vanguardium.Infra.ORM.EntitiesMapping.Base;

namespace Vanguardium.Infra.ORM.EntitiesMapping;

public sealed class AddressMapping : BaseMapping, IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(nameof(Address), Schema);
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(a => a.State)
            .HasColumnType("varchar(150)")
            .HasColumnName("state")
            .IsUnicode()
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(a => a.City)
            .HasColumnType("varchar(150)")
            .HasColumnName("city")
            .IsUnicode()
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(a => a.District)
            .HasColumnType("varchar(150)")
            .HasColumnName("district")
            .IsUnicode()
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(a => a.Street)
            .HasColumnType("varchar(150)")
            .HasColumnName("street")
            .IsUnicode()
            .HasColumnOrder(5)
            .IsRequired();

        builder.Property(a => a.Country)
            .HasColumnType("varchar(80)")
            .HasColumnName("country")
            .IsUnicode()
            .HasColumnOrder(7)
            .IsRequired();

        builder.Property(a => a.PostalCode)
            .HasColumnType("varchar(30)")
            .HasColumnName("zip_code")
            .HasColumnOrder(8)
            .IsRequired();

        builder.Property(a => a.Complement)
            .HasColumnType("varchar(200)")
            .HasColumnName("complement")
            .IsUnicode()
            .HasColumnOrder(9)
            .IsRequired(false);
    }
}