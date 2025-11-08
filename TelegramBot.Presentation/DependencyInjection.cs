using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TelegramBot.Infrastructure.Data;
using TelegramBot.Infrastructure.Data.Repositories;
using TelegramBot.Infrastructure.Telegram;
using TelegramBot.Application.Services;
using TelegramBot.Domain.Interfaces;

namespace TelegramBot.Presentation
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