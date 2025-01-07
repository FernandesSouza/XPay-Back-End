using Vanguardium.ApplicationService.Dtos.UserDtos.Response;

namespace Vanguardium.ApplicationService.Interfaces;

public interface IUserQueryService
{
    Task<List<UserSimpleResponse>> GetAllUser();
}