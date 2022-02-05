using Autofac;
using Autofac.Extensions.DependencyInjection;
using HotelsHubApp.Business.DependencyResolvers.Autofac;
using HotelsHubApp.Business.HttpRequests.Hotelbeds;
using HotelsHubApp.Core.DependencyResolvers.Autofac;
using HotelsHubApp.Core.DependencyResolvers.Microsoft;
using HotelsHubApp.Core.Extensions;
using HotelsHubApp.Core.RedisClient.Concrete;
using HotelsHubApp.Core.RedisClient.Options;
using HotelsHubApp.Core.Utilities.IoC;
using HotelsHubApp.WebAPI.Middleware;
using Newtonsoft.Json;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host
.UseSerilog((ctx, lc) =>
{
    lc.WriteTo.Console();
})
.UseServiceProviderFactory(new AutofacServiceProviderFactory())
.ConfigureContainer<ContainerBuilder>(builder1 =>
{
    builder1.RegisterModule(new AutofacCoreModule());
    builder1.RegisterModule(new AutofacBusinessModule());
});

//Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    //request is coming null when its include
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString |
                                                   JsonNumberHandling.WriteAsString;
});

builder.Services.AddScoped<RedisServer>();
builder.Services.Configure<RedisOptions>(builder.Configuration.GetSection("RedisOptions"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddDependencyResolvers(new IBaseModule[] { new CoreModule() });
builder.Services.AddHttpClient<HotelbedsService>();


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
