using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Vanguardium.Domain.Interface;
using Vanguardium.Extensions;

namespace Vanguardium.Filters;

public sealed class NotificationFilter(
    INotificationHandler notificationHandler)
    : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (!context.IsMethodGet() && notificationHandler.HasNotification())
            context.Result = new BadRequestObjectResult(notificationHandler.GetNotifications());

        base.OnActionExecuted(context);
    }
}


