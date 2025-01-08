using MassTransit;
using Vanguardium.ApplicationService.Dtos.RabbitDtos;
using Vanguardium.ApplicationService.Interfaces;

namespace Vanguardium.ApplicationService.RabbitMqServices;

public sealed class CreatingProducers(
    IBus bus,
    ITransferMapper transferMapper) : ICreatingProducers
{
    public async Task PublishTransfer(TransferProducerDto transferProducerDto)
    {
        var message = transferMapper.DtoToMessaging(transferProducerDto);
        await bus.Publish(message, context =>
        {
            context.SetRoutingKey("transfer.validate");
        });
    }
}