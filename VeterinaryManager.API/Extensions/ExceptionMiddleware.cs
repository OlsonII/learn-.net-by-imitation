using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using VeterinaryManager.Domain.Models.Common;

namespace VeterinaryManager.API.Extensions
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = contextFeature.Error;
                    switch (exception)
                    {
                        // case UsersManagerException usersManagerException:
                        //     usersManagerException.SetHttpResponse(context);
                        //     break;
                        default:
                            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                            await context.Response.WriteAsync(new ErrorDetails
                            {
                                Code = 500, // TODO: Use enum here
                                Title = "Internal Server error"
                            }.ToString());
                            break;
                    }
                });
            });
        }
    }
}