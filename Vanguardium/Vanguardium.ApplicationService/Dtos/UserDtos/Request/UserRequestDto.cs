using Vanguardium.ApplicationService.Dtos.AddresDtos.Request;
using Vanguardium.Domain.Enums;

namespace Vanguardium.ApplicationService.Dtos.UserDtos.Request;

public sealed record UserRequestDto
{
    public required string Name { get; set; }
    public required string Document { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required DateTime CreationDate { get; set; }
    public required string DateOfBirth { get; set; }
    public required Gender Gender { get; set; }
    public AddresRegisterRequestDto? Address { get; set; }
    public required ERole Role { get; set; }
    public required string Telephone { get; set; }
}