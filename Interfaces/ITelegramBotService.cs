using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Interfaces
{
    public interface ITelegramBotService
    {
        /// <summary>
        /// Обработка входящего обновления от Telegram (Webhook или Polling)
        /// </summary>
        Task HandleUpdateAsync(Update update);

        /// <summary>
        /// Отправка текстового сообщения пользователю
        /// </summary>
        Task SendMessageAsync(long chatId, string message);

        /// <summary>
        /// Обработка команды /start
        /// </summary>
        Task HandleStartCommandAsync(long chatId);

        /// <summary>
        /// Обработка команды /addexpense
        /// </summary>
        Task HandleAddExpenseAsync(long chatId, string messageText);

        /// <summary>
        /// Обработка команды /summary
        /// </summary>
        Task HandleSummaryCommandAsync(long chatId);
    }
}