using Core.DataAccess.Context;
using HotelsHubApp.Business.HttpRequests.Hotelbeds;
using HotelsHubApp.Core.DependencyResolvers.Microsoft;
using HotelsHubApp.Core.Extensions;
using HotelsHubApp.Core.RedisClient.Options;
using HotelsHubApp.Core.Utilities.IoC;
using HotelsHubApp.WebAPI.Extensions;
using HotelsHubApp.WebAPI.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//builder extension
BuilderExtensionClass.BuilderExtension(builder);


//Add services to the container.
builder.Services.Configure<RedisOptions>(builder.Configuration.GetSection("RedisOptions"));
builder.Services.AddDependencyResolvers(new IBaseModule[] { new CoreModule() });
builder.Services.AddHttpClient<HotelbedsService>();
builder.Services.AddDbContext<HotelbedsDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionString"]);
});
builder.Services.AddMongoDbSettings(builder.Configuration);

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
