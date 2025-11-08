
using TelegramBot.Presentation; // 👈 подключаем пространство имён
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TelegramBotService, TelegramBotService>();

var app = builder.Build();

// Запускаем Polling
var botService = app.Services.GetRequiredService<TelegramBotService>();
botService.Start();
app.Run();