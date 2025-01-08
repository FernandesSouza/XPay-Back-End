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
        await bus.Publish(transferMapper.DtoToMessaging(transferProducerDto), context =>
        {
            context.SetRoutingKey("transfer.validate");
        });
    }
}