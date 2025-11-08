public class BotUpdateHandler : IBotUpdateHandler
{
    public async Task HandleAsync(string messageText, long chatId, CancellationToken token)
    {
        // Бизнес-логика обработки команд
        if (messageText == "/start")
        {
            // например, вызвать INotificationService.Send(chatId, "Привет!")
        }
    }
}