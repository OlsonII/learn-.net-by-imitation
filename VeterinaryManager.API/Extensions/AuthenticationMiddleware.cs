using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VeterinaryManager.Domain.Utils;

namespace VeterinaryManager.API.Extensions;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method )]
public class AuthenticationMiddleware : Attribute, IAsyncAuthorizationFilter
{
    private readonly JsonResult _unauthorizedResultContext = new(new {message = "Unauthorized"})
    {
        StatusCode = StatusCodes.Status401Unauthorized
    };

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var apiKey = ExtractApikeyFromRequest(context.HttpContext.Request);
        
        if (string.IsNullOrEmpty(apiKey))
        {
            context.Result = _unauthorizedResultContext;
            return;
        }

        await ValidateCredentials(context, apiKey);
    }
    
    private static string ExtractApikeyFromRequest(HttpRequest request)
    {
        var headerValue = request.Headers
            .FirstOrDefault(header => header.Key == "api-key")
            .Value.ToString();
        return headerValue;
    }
    
    private async Task ValidateCredentials(ActionContext context, string apiKey)
    {
        if (apiKey.Equals(EnvironmentManger.ApiKey))
            return;
        // TODO: Make Unauthorized flow
    }
}