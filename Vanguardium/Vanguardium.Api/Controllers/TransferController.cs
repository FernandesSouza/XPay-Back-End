using Microsoft.AspNetCore.Mvc;
using Vanguardium.ApplicationService.Dtos.RabbitDtos;
using Vanguardium.ApplicationService.Interfaces;
using Vanguardium.Domain.Handlers.NotificationHandler;

namespace Vanguardium.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class TransferController(
        ICreatingProducers creatingProducers
    ) : ControllerBase
{
    [HttpPost("transfer_publisher")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task SaveUserAsync(TransferProducerDto userRequestDto) =>
       await creatingProducers.PublishTransfer(userRequestDto);
}