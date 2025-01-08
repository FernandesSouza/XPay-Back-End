using Vanguardium.ApplicationService.Dtos.RabbitDtos;
using Vanguardium.ApplicationService.Interfaces;
using Vanguardium.Domain.Entities;
using Vanguardium.Domain.Enums;

namespace Vanguardium.ApplicationService.Mappers;

public sealed class TransferMapper : ITransferMapper
{
    public Transfers DomainToRequest(TransferMessage transferMessage) =>
        new()
        {
            SenderId = transferMessage.SenderId,
            RecipientId = transferMessage.RecipientId,
            ValueForTransfer = transferMessage.ValueForTransfer,
            CreateDate = transferMessage.CreateDate,
            StatusTransfer = (StatusTransfer)0
        };

    public TransferMessage DtoToMessaging(TransferProducerDto transferProducerDto) =>
        new()
        {
            SenderId = transferProducerDto.SenderId,
            RecipientId = transferProducerDto.RecipientId,
            ValueForTransfer = transferProducerDto.ValueForTransfer,
            CreateDate = transferProducerDto.CreateDate,
            StatusTransfer = transferProducerDto.StatusTransfer
        };
}