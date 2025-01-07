using Vanguardium.Domain.Enums;

namespace Vanguardium.Domain.Entities;

public sealed class User
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Document { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public DateTime CreationDate { get; init; }
    public string? DateOfBirth { get; init; }
    public Gender? Gender { get; init; }
    public required bool Status { get; init; }
    public required ERole Role { get; init; }
    public long? AddressId { get; init; }
    public Address? Address { get; init; }
    public string? Telephone { get; init; }
    public List<Transfers>? Transfers { get; set; }
    public decimal? Balance { get; set; }
}