using FluentValidation;
using HotelsHubApp.Core.RabbitMQClient.Abstract;
using System.Net;
using System.Text.Json;

namespace HotelsHubApp.WebAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private IPublisherService _publisherService;

        public ExceptionHandlingMiddleware(RequestDelegate next, IPublisherService publisherService)
        {
            _next = next;
            _publisherService = publisherService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception error)
            {
                HttpStatusCode status;
                var response = httpContext.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        status = HttpStatusCode.BadRequest;

                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        status = HttpStatusCode.InternalServerError;

                        break;
                }

                var result = JsonSerializer.Serialize(new ApiResponse<object> { ErrorMessage = error?.Message, StatusCode = (int)status });
                _publisherService.SendData<string>("errorLog", result);
                await response.WriteAsync(result);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}