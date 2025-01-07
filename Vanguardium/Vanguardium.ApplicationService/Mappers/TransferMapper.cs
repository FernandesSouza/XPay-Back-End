using Vanguardium.ApplicationService.Interfaces;
using Vanguardium.Domain.Entities;
using Vanguardium.Domain.Enums;

namespace Vanguardium.ApplicationService.Mappers;

public sealed class TransferMapper : ITransferMapper
{
    public Transfers DomainToRequest(Dtos.RabbitDtos.TransferMessage transferMessage) =>
        new()
        {
            SenderId = transferMessage.SenderId,
            RecipientId = transferMessage.RecipientId,
            ValueForTransfer = transferMessage.ValueForTransfer,
            CreateDate = transferMessage.CreateDate,
            StatusTransfer = (StatusTransfer)0
        };

}