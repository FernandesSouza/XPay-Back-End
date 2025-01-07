using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vanguardium.Domain.Entities;
using Vanguardium.Infra.ORM.EntitiesMapping.Base;

namespace Vanguardium.Infra.ORM.EntitiesMapping;

public sealed class UserMapping : BaseMapping, IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User), Schema);
        builder.HasKey(a => a.Id);

        builder.Property(c => c.Id)
            .HasColumnType("uniqueidentifier")
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .HasColumnOrder(1);

        builder.Property(a => a.Name)
            .HasColumnType("varchar(150)")
            .HasColumnName("name")
            .IsUnicode()
            .HasColumnOrder(2);

        builder.Property(a => a.Document)
            .HasColumnType("varchar(50)")
            .HasColumnName("document")
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(a => a.Email)
            .HasColumnType("varchar(50)")
            .HasColumnName("email")
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(a => a.Password)
            .HasColumnType("varchar(50)")
            .HasColumnName("password")
            .HasColumnOrder(5)
            .IsRequired();

        builder.Property(a => a.Telephone)
            .HasColumnType("varchar(50)")
            .HasColumnName("telephone")
            .HasColumnOrder(6)
            .IsRequired();

        builder.Property(a => a.Status)
            .HasColumnType("bit")
            .HasColumnName("status")
            .HasColumnOrder(7)
            .IsRequired();

        builder.Property(a => a.Role)
            .HasColumnType("tinyint")
            .HasColumnName("role")
            .HasColumnOrder(8)
            .IsRequired();

        builder.Property(a => a.Gender)
            .HasColumnType("tinyint")
            .HasColumnName("genero")
            .HasColumnOrder(9)
            .IsRequired();

        builder.HasOne(c => c.Address)
            .WithOne()
            .HasForeignKey<User>(c => c.AddressId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasMany(c => c.Transfers)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        builder.Property(u => u.Balance)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("balance")
            .HasColumnOrder(10)
            .IsRequired(false);
    }
}