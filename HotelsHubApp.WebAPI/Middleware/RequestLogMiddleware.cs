using HotelsHubApp.Core.CrossCuttingConcerns.Logging.LogModels;
using Serilog;
using System.Diagnostics;

namespace HotelsHubApp.WebAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task Invoke(HttpContext httpContext)
        {
            var log = new EndpointLogDetail
            {
                RequestMethod = httpContext.Request.Method,
                RequestTimestamp = DateTime.Now,
                RequestPath = httpContext.Request.Path
            };
            if (httpContext.Request.Method == "POST")
            {
                httpContext.Request.EnableBuffering();
                var body = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();
                httpContext.Request.Body.Position = 0;
                log.RequestContent = body;
            }
            var watch = new Stopwatch();
            watch.Start();
            try
            {
                httpContext.Response.OnStarting(() =>
                {
                    watch.Stop();
                    return Task.CompletedTask;
                });
                await _next(httpContext);
            }
            finally
            {
                log.ResponseTime = watch.ElapsedMilliseconds;
                log.ResponseContentType = httpContext.Response.ContentType;
                log.ResponseStatusCode = httpContext.Response.StatusCode.ToString();

                Log.Information("{@EndpointLogDetail}", log);
            }


        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestLogHandlerExtensions
    {
        public static IApplicationBuilder UseRequestLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogMiddleware>();
        }
    }
}
