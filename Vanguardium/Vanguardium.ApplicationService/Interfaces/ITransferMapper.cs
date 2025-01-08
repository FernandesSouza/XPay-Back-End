using Vanguardium.ApplicationService.Dtos.RabbitDtos;
using Vanguardium.Domain.Entities;

namespace Vanguardium.ApplicationService.Interfaces;

public interface ITransferMapper
{
    Transfers DomainToRequest(TransferMessage transferMessage);
    TransferMessage DtoToMessaging(TransferProducerDto transferProducerDto);
}