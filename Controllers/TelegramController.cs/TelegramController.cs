using Telegram.Bot;
using Telegram.Bot.Types;

public class TelegramBotService : ITelegramBotService
{
    private readonly TelegramBotClient _botClient;

    public TelegramBotService(IConfiguration config)
    {
        var token = config["Telegram:Token"];
        _botClient = new TelegramBotClient(token??"NotNullToken");
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
}