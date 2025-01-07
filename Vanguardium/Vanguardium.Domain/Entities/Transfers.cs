using Vanguardium.Domain.Enums;

namespace Vanguardium.Domain.Entities;

public sealed class Transfers
{
    public long Id { get; init; }
    public Guid SenderId { get; init; }
    public Guid RecipientId { get; init; }
    public decimal ValueForTransfer { get; init; }
    public DateTime CreateDate { get; init; }
    public StatusTransfer StatusTransfer { get; set; }
}