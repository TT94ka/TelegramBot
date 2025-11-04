using TelegramBot.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITelegramBotService, TelegramBotService>();

var app = builder.Build();

// Запускаем Polling
var botService = app.Services.GetRequiredService<ITelegramBotService>();
botService.Start();

app.Run();

