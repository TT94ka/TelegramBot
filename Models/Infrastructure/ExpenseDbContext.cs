using Microsoft.EntityFrameworkCore;

public class ExpenseDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Expense> Expenses { get; set; }

    public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.ChatId)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasMany(u => u.Expenses)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);
    }
}