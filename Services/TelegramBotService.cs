using Telegram.Bot.Types;
using System.Threading.Tasks;

public interface ITelegramBotService
{
    Task HandleUpdateAsync(Update update);
}