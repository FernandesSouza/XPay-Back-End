using Microsoft.AspNetCore.Mvc;
using Vanguardium.ApplicationService.Dtos.UserDtos.Request;
using Vanguardium.ApplicationService.Dtos.UserDtos.Response;
using Vanguardium.ApplicationService.Interfaces;
using Vanguardium.Domain.Handlers.NotificationHandler;

namespace Vanguardium.Controllers;

// [Authorize]
[Route("api/[Controller]")]
[ApiController]
public class UserController(
    IUserCommandService commandService,
    IUserQueryService queryService) : ControllerBase
{
    [HttpPost("user_register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(IEnumerable<DomainNotification>))]
    public Task<bool> SaveUserAsync(UserRequestDto userRequestDto) =>
        commandService.SaveAsync(userRequestDto);

    [HttpGet("get_all_users_by_company")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(IEnumerable<DomainNotification>))]
    public Task<List<UserSimpleResponse>> GetAllUsersByPredicate() =>
        queryService.GetAllUser();
}