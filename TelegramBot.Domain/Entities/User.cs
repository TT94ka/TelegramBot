namespace TelegramBot.Domain.Entities;

public class User
{
    public int Id { get; set; }

    public long ChatId { get; set; } // Telegram ID, уникальный для пользователя

    public string Username { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}