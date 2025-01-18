using Moq;
using Vanguardium.ApplicationService.Interfaces;
using Vanguardium.ApplicationService.Service;
using Vanguardium.Infra.Interfaces;

namespace Vanguardium.UnitTest.Services.UserCommandServices.Base;

public abstract class UserCommandServiceSetup
{
    protected readonly Mock<IUserRepository> UserRepository;
    protected readonly Mock<IUserMapper> UserMapper;
    protected readonly UserCommandService UserCommandService;

    protected UserCommandServiceSetup()
    {
        UserRepository = new Mock<IUserRepository>();
        UserMapper = new Mock<IUserMapper>();
        UserCommandService = new UserCommandService(
            UserRepository.Object,
            UserMapper.Object);
    }
}