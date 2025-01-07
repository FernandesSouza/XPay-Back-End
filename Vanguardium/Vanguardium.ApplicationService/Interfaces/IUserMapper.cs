using Vanguardium.ApplicationService.Dtos.UserDtos.Request;
using Vanguardium.ApplicationService.Dtos.UserDtos.Response;
using Vanguardium.Domain.Entities;

namespace Vanguardium.ApplicationService.Interfaces;

public interface IUserMapper
{
    User DomainToRequest(UserRequestDto userRequestDto);
    List<UserSimpleResponse> DtoToResponse(List<User> user);

}