
namespace ExpenseBot.Domain.Interfaces
{
    public interface ITelegramBotService
    {
        Task HandleErrorAsync(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token);
        /// <summary>
        /// Обработка ошибок
        /// </summary>
        Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token);
        /// <summary>
        /// Обработка входящего обновления от Telegram (Webhook или Polling)
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
        /// <summary>
        /// 
        /// </summary>
        void Start();
        /// <summary>
        /// 
        /// </summary>
    }
}