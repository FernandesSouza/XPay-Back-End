namespace Vanguardium.Domain.Entities;

public sealed class UserCompany
{
    public long Id { get; set; }
    public required Guid UserId { get; set; }
    public required long CompanyId { get; set; }
}