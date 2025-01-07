using Vanguardium.Domain.Enums;

namespace Vanguardium.ApplicationService.Dtos.UserDtos.Response;

public sealed record UserSimpleResponse
{
    public required string Name { get; set; }
    public required string Document { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Gender? Gender { get; set; }
    public required bool Status { get; set; }
}