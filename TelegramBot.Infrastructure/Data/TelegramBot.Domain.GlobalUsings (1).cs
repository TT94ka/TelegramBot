using Microsoft.EntityFrameworkCore;
using TelegramBot.Domain.Entities;

namespace TelegramBot.Infrastructure.Data
{
    public class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options)
            : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }
    }