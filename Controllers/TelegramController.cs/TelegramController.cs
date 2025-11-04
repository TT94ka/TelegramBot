using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Interfaces;


public class TelegramBotService : ITelegramBotService
{
    private readonly TelegramBotClient _botClient;

    public TelegramBotService(IConfiguration config)
    {
        var token = config["Telegram:Token"];
        _botClient = new TelegramBotClient(token??"NotNullToken");
    }

    public Task HandleAddExpenseAsync(long chatId, string messageText)
    {
        throw new NotImplementedException();
    }

    public Task HandleStartCommandAsync(long chatId)
    {
        throw new NotImplementedException();
    }

    public Task HandleSummaryCommandAsync(long chatId)
    {
        throw new NotImplementedException();
    }

    public async Task HandleUpdateAsync(Update update)
    {
        if (update.Message?.Text != null)
        {
            var chatId = update.Message.Chat.Id;
            var text = update.Message.Text;

            await _botClient.SendMessage(chatId, $"Text: {text}");
        }
    }

    public Task SendMessageAsync(long chatId, string message)
    {
        throw new NotImplementedException();
    }
}