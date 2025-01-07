using Vanguardium.Domain.Enums;

namespace Vanguardium.ApplicationService.Dtos.RabbitDtos;

public sealed record TransferMessage
{
    public Guid SenderId { get; init; }
    public Guid RecipientId { get; init; }
    public int ValueForTransfer { get; init; }
    public DateTime CreateDate { get; init; }
    public StatusTransfer StatusTransfer { get; init; }
}