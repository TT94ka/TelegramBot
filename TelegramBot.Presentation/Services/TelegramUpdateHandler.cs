using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Application.Interfaces;

namespace TelegramBot.Presentation.Services;
public class TelegramUpdateHandler
{
    private readonly IBotUpdateHandler _botHandler;

    public TelegramUpdateHandler(IBotUpdateHandler botHandler)
    {
        _botHandler = botHandler;
    }

    public async Task HandleAsync(ITelegramBotClient client, Update update, CancellationToken token)
    {
        if (update.Message is { Text: var text, Chat: var chat })
        {
            await _botHandler.HandleAsync(text, chat.Id, token);
        }
    }
}