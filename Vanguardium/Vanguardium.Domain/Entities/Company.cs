namespace Vanguardium.Domain.Entities;

public sealed class Company
{
    public required long Id { get; init; }
    public required string CorporateName { get; init; }
    public required string Document { get; init; }
    public long? AddressId { get; init; }
    public string? ContactNumber { get; init; }
    public Address? Address { get; init; }
    public required decimal Balance { get; set; }
}