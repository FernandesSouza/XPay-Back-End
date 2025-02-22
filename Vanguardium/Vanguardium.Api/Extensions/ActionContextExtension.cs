﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace Vanguardium.Extensions;

public static class ActionContextExtension
{
    public static string? GetEndPointName(this ActionExecutedContext executedContext)
    {
        var routeData = executedContext.HttpContext.GetRouteData();

        return routeData.Values["action"]?.ToString();
    }
}