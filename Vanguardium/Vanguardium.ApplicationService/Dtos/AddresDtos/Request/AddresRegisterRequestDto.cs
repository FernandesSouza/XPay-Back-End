namespace Vanguardium.ApplicationService.Dtos.AddresDtos.Request;

public sealed record AddresRegisterRequestDto
{
    public required string Street { get; init; }
    public required string District { get; init; }
    public required string PostalCode { get; init; }
    public required string City { get; init; }
    public required string Country { get; init; }
    public required string State { get; init; }
    public string? Complement { get; init; }
}