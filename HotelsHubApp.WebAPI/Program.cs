using HotelsHubApp.WebAPI.Extensions;
using HotelsHubApp.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

BuilderExtensionClass.BuilderExtension(builder);

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
