using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vanguardium.Domain.Entities;
using Vanguardium.Infra.ORM.EntitiesMapping.Base;

namespace Vanguardium.Infra.ORM.EntitiesMapping;

public sealed class TransferMapping : BaseMapping, IEntityTypeConfiguration<Transfers>
{
    public void Configure(EntityTypeBuilder<Transfers> builder)
    {
        builder.ToTable(nameof(Transfers), Schema);
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(t => t.SenderId)
            .HasColumnType("uniqueidentifier")
            .HasColumnName("senderId")
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(t => t.RecipientId)
            .HasColumnType("uniqueidentifier")
            .HasColumnName("recipientId")
            .HasColumnOrder(3)
            .IsRequired();

        builder.Property(t => t.ValueForTransfer)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("value")
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(c => c.CreateDate)
            .HasColumnType("datetime2")
            .HasColumnName("create_date")
            .HasColumnOrder(5)
            .IsRequired();

        builder.Property(a => a.StatusTransfer)
            .HasColumnType("tinyint")
            .HasColumnName("statusTransfer")
            .HasColumnOrder(6)
            .IsRequired();
    }
}