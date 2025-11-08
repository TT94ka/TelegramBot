using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using TelegramBot.Application.Interfaces;

public class TelegramUpdateHandler : IUpdateHandler
{
    private readonly IBotUpdateHandler _botHandler;

    public TelegramUpdateHandler(IBotUpdateHandler botHandler)
    {
        _botHandler = botHandler;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is { Text: var text, Chat: var chat })
        {
            await _botHandler.HandleAsync(text, chat.Id, cancellationToken);
        }
    }

    public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiEx => $"Telegram API Error: [{apiEx.ErrorCode}] {apiEx.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine($"❌ {errorMessage}");
        return Task.CompletedTask;
    }
}