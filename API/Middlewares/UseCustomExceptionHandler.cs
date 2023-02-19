using Business.Exceptions;
using Entity.DTOs;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    context.Response.ContentType= "application/json";
                    var exceptionFetaure=context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFetaure.Error switch
                    {

                        ClientSideException=>400,
                        _=>500
                    };
                    context.Response.StatusCode = statusCode;
                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode,exceptionFetaure.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
