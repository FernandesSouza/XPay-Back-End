using MassTransit;
using Vanguardium.ApplicationService.Dtos.RabbitDtos;
using Vanguardium.ApplicationService.Interfaces;
using Vanguardium.Domain.Enums;

namespace Vanguardium.ApplicationService.RabbitMqServices;

public sealed class CreatingProducers(IBus bus) : ICreatingProducers
{
    public async Task PublishTransfer(TransferProducerDto transferProducerDto)
    {
        await bus.Publish(new TransferMessage
        {
            SenderId = transferProducerDto.SenderId,
            RecipientId = transferProducerDto.RecipientId,
            ValueForTransfer = transferProducerDto.ValueForTransfer,
            CreateDate = transferProducerDto.CreateDate,
            StatusTransfer = StatusTransfer.Awaiting,
        }, context => { context.SetRoutingKey("transfer.validate"); });
    }
}