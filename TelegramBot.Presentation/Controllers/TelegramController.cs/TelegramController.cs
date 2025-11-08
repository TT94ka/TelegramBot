using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Application.Interfaces;

public class TelegramBotService : ITelegramBotService
{
    private readonly TelegramBotClient _botClient;

    public TelegramBotService(IConfiguration config)
    {
        var token = config["Telegram:Token"];
        _botClient = new TelegramBotClient(token ?? "NotNullToken");
    }

    public async Task HandleAddExpenseAsync(long chatId, string messageText)
    {
        // Пример: /addexpense 150 Продукты
        var parts = messageText.Split(' ', 3);
        if (parts.Length < 3 || !decimal.TryParse(parts[1], out var amount))
        {
            await SendMessageAsync(chatId, "⚠️ Используй формат: /addexpense 150 Продукты");
            return;
        }

        var category = parts[2];
        // Здесь можно сохранить в БД, пока просто выводим
        await SendMessageAsync(chatId, $"✅ Добавлен расход: {amount} BYN на \"{category}\"");
    }

    public Task HandleErrorAsync(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task HandleStartCommandAsync(long chatId)
    {
        await SendMessageAsync(chatId, "👋 Привет! Я бот учёта расходов. Используй /addexpense для добавления расхода.");
    }

    public async Task HandleSummaryCommandAsync(long chatId)
    {
        // Пока просто пример
        await SendMessageAsync(chatId, "📊 Сводка расходов пока не реализована.");
    }

    public async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
    {
        if (update.Message?.Text == null) return;

        var chatId = update.Message.Chat.Id;
        var text = update.Message.Text;

        if (text.StartsWith("/start"))
            await HandleStartCommandAsync(chatId);
        else if (text.StartsWith("/addexpense"))
            await HandleAddExpenseAsync(chatId, text);
        else if (text.StartsWith("/summary"))
            await HandleSummaryCommandAsync(chatId);
        else
            await SendMessageAsync(chatId, "❓ Неизвестная команда.");
    }

    public async Task SendMessageAsync(long chatId, string message)
    {
        await _botClient.SendMessage(chatId, message);
    }

    public void Start()
    {
        var cancellationToken = new CancellationTokenSource().Token;

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        _botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            errorHandler: HandleErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cancellationToken
        );

        Console.WriteLine("✅ Bot running in Polling mode");
    }
}