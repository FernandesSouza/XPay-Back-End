using Vanguardium.Domain.Enums;

namespace Vanguardium.Domain.Handlers.PaginationHandler.Filters;

public sealed class UserFilter : PageParams
{
    public Gender Gender  { get; set; }
}