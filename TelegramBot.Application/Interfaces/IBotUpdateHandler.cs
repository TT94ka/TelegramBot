
public interface IBotUpdateHandler
{
    Task HandleAsync(string message, long chatId, CancellationToken token);
}