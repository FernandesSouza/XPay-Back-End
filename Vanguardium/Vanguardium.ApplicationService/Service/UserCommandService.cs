using Vanguardium.ApplicationService.Dtos;
using Vanguardium.ApplicationService.Dtos.UserDtos.Request;
using Vanguardium.ApplicationService.Interfaces;
using Vanguardium.Infra.Interfaces;

namespace Vanguardium.ApplicationService.Service;

public sealed class UserCommandService(
    IUserRepository userRepository,
  IUserMapper userMapper ) : IUserCommandService
{
    public async Task<bool> SaveAsync(UserRequestDto userRequestDto)
    {
        var user = userMapper.DomainToRequest(userRequestDto);

        return await userRepository.SaveAsync(user);
    }
}