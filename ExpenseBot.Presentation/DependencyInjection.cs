using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ExpenseBot.Infrastructure.Data;
using ExpenseBot.Infrastructure.Data.Repositories;
using ExpenseBot.Infrastructure.Telegram;
using ExpenseBot.Application.Services;
using ExpenseBot.Domain.Interfaces;

namespace ExpenseBot.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            // PostgreSQL через EF Core
            services.AddDbContext<ExpenseDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Postgres")));

            // Репозитории
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Сервисы бизнес-логики
            services.AddScoped<ExpenseService>();
            services.AddScoped<UserService>();

            // Telegram-бот через Polling
            services.AddHostedService<TelegramBotService>();

            return services;
        }
    }
}