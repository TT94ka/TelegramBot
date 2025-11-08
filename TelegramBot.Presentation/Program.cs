using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TelegramBot.Application.Interfaces;
using TelegramBot.Infrastructure;
using TelegramBot.Application;
using TelegramBot.Presentation;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        config.AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;

        // Подключаем слои
        services.AddApplication();     // IServiceCollection расширение из Application
        services.AddInfrastructure(configuration); // IServiceCollection расширение из Infrastructure
        services.AddPresentation(configuration);    // если есть Presentation-specific DI
        //services.AddHostedService<TelegramBotService>();
        // Логирование
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Information);
        });
    })
    .Build();

// Получаем TelegramBotService и запускаем
var botService = host.Services.GetRequiredService<ITelegramBotService>();
botService.Start();

await host.RunAsync();