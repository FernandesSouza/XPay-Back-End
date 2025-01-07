using Vanguardium.ApplicationService.Dtos.UserDtos.Response;
using Vanguardium.ApplicationService.Interfaces;
using Vanguardium.Infra.Interfaces;

namespace Vanguardium.ApplicationService.Service;

public sealed class UserQueryService(
    IUserRepository userRepository,
    IUserMapper userMapper
) : IUserQueryService
{
    public async Task<List<UserSimpleResponse>> GetAllUser()
    {
        var user = await userRepository.GetAllAsync();

        return user.Count != 0 ? userMapper.DtoToResponse(user) : [];
    }
}