using Vanguardium.ApplicationService.Dtos.RabbitDtos;

namespace Vanguardium.ApplicationService.Interfaces;

public interface ICreatingProducers
{
    Task PublishTransfer(TransferProducerDto transferProducerDto);
}