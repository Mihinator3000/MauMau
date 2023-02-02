using Microsoft.AspNetCore.SignalR;

namespace MauMau.WebApi.Services;

public class AuthFilter : IHubFilter
{
    public async ValueTask<object?> InvokeMethodAsync(
        HubInvocationContext invocationContext,
        Func<HubInvocationContext, ValueTask<object?>> next)
    {
        HttpContext? httpContext = invocationContext.Context.GetHttpContext();

        string? authCookie = httpContext?.Request.Cookies["AuthCookie"];

        if (string.IsNullOrEmpty(authCookie) || !IsCookieValid(authCookie))
        {
            //throw new HubException("Unauthorized");
        }
        
        return await next(invocationContext);
    }

    private bool IsCookieValid(string authCookie)
    {
        throw new NotImplementedException();
    }
}