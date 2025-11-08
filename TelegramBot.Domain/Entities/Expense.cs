namespace TelegramBot.Domain.Entities;
public class Expense
{
    public int Id { get; set; }

    public long ChatId { get; set; } // дублируем для быстрого поиска

    public decimal Amount { get; set; }

    public string Category { get; set; } = string.Empty;

    public DateTime Date { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; } // внешний ключ

    public User User { get; set; } = null!;
}