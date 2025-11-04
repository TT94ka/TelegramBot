using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Interfaces;

namespace TelegramBot.Services
{
    public class TelegramBotService : ITelegramBotService
    {
        private readonly ITelegramBotClient _botClient;

        public TelegramBotService(IConfiguration config)
        {
            var token = config["Telegram:Token"]!;
            _botClient = new TelegramBotClient(
                new TelegramBotClientOptions(token),
                new HttpClient()
            );

        }

        public async Task HandleUpdateAsync(Update update)
        {
            if (update.Message?.Text == null) return;

            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;

            if (messageText.StartsWith("/start"))
                await HandleStartCommandAsync(chatId);
            else if (messageText.StartsWith("/addexpense"))
                await HandleAddExpenseAsync(chatId, messageText);
            else if (messageText.StartsWith("/summary"))
                await HandleSummaryCommandAsync(chatId);
            else
                await SendMessageAsync(chatId, "❓ Unknown command. Retry /start or /help");
        }

        public async Task SendMessageAsync(long chatId, string message)
        {
            await _botClient.SendMessage(
    chatId: chatId,
    text: message
);
        }

        public async Task HandleStartCommandAsync(long chatId)
        {
            var welcome = "👋 Hi! I am summary bot.\n" +
                          "Available commands:\n" +
                          "/addexpense <amount> <category>\n" +
                          "/summary — show u balance";
            await SendMessageAsync(chatId, welcome);
        }

        public async Task HandleAddExpenseAsync(long chatId, string messageText)
        {
            var parts = messageText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 3)
            {
                await SendMessageAsync(chatId, "⚠️ Format: /addexpense <amount> <category>");
                return;
            }

            if (!decimal.TryParse(parts[1], out var amount))
            {
                await SendMessageAsync(chatId, "⚠️ Incorrect amount. Example: /addexpense 25 food");
                return;
            }

            var category = parts[2];
            // TODO: сохранить в БД

            await SendMessageAsync(chatId, $"✅ Expense {amount} BYN in category \"{category}\" added.");
        }

        public async Task HandleSummaryCommandAsync(long chatId)
        {
            // TODO: получить данные из БД
            var summary = "💰 Income: 0 BYN\n💸 Expense: 0 BYN\n📈 Balance: 0 BYN";
            await SendMessageAsync(chatId, summary);
        }
    }
}