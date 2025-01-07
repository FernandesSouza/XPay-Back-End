using Vanguardium.ApplicationService.Dtos;
using Vanguardium.ApplicationService.Dtos.UserDtos.Request;

namespace Vanguardium.ApplicationService.Interfaces;

public interface IUserCommandService
{
    Task<bool> SaveAsync(UserRequestDto userRequestDto);
}