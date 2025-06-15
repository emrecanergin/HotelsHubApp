using Autofac.Core;
using HotelsHubApp.Business.Concrete.Hotelbeds.Helper.Searching;
using HotelsHubApp.Core.RabbitMQClient.Abstract;
using HotelsHubApp.Core.RabbitMQClient.Concrete;
using HotelsHubApp.WebAPI.Extensions;
using HotelsHubApp.WebAPI.Middleware;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Serilog;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// CORS Policy Ekleniyor
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

BuilderExtensionClass.BuilderExtension(builder);
builder.Services.AddScoped<IGetHotels, GetHotels>();

// JSON serialization performans optimizasyonları
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    options.SerializerOptions.WriteIndented = false; // Minimize JSON size
    options.SerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
});
builder.Services.AddHttpLogging((opt) =>
{
    opt.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
});

// Serilog Configuration - Configure from separate config file like worker service
var serilogConfig = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("serilogConfiguration.json")
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(serilogConfig)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotels Hub API V1");
        // Basit konfigürasyon - tüm optimizasyonları kaldırdık
    });
}

//custom middlewares - Güvenli olanlar açık
app.UseExceptionHandlingMiddleware();
app.UseRequestLogMiddleware();
app.UseTimesMiddleware();

// Static files middleware ekleniyor
app.UseStaticFiles();

app.UseRouting();

// CORS middleware ekleniyor
app.UseCors("AllowAll");

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
