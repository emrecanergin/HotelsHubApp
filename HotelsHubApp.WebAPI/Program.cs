using Autofac.Core;
using HotelsHubApp.Business.Concrete.Hotelbeds.Helper.Searching;
using HotelsHubApp.Core.RabbitMQClient.Abstract;
using HotelsHubApp.Core.RabbitMQClient.Concrete;
using HotelsHubApp.WebAPI.Extensions;
using HotelsHubApp.WebAPI.Middleware;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

BuilderExtensionClass.BuilderExtension(builder);
//builder.Configuration.GetSection("RabbitMqConnection").Bind(connectionFactory);
builder.Services.AddScoped<IGetHotels, GetHotels>();
//builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddHttpLogging((opt) =>
{
    opt.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
});



builder.Host.UseSerilog((context,config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//custom
app.UseExceptionHandlingMiddleware();

//custom
app.UseRequestLogMiddleware();

app.UseTimesMiddleware();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("worker process name : " +
            System.Diagnostics.Process.GetCurrentProcess().ProcessName + "  time : " + DateTime.Now);
    });
});

app.Run();
