using Autofac.Core;
using HotelsHubApp.Core.RabbitMQClient.Abstract;
using HotelsHubApp.Core.RabbitMQClient.Concrete;
using HotelsHubApp.LoggingWorkerService;
using HotelsHubApp.LoggingWorkerService.RabbitMq;

using Serilog;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton(Log.Logger);
builder.Services.AddSingleton<IMessageConsumer, MessageConsumer>();
builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();
builder.Services.AddHostedService<Worker>();

var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("serilogConfigurationWorker.json")
                .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(conf)
    .CreateLogger();
// add the provider
builder.Logging.AddSerilog();




var host = builder.Build();
host.Run();

