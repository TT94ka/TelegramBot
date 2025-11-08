using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using TelegramBot.Application.Interfaces;

namespace TelegramBot.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration config)
        {
            // PostgreSQL через EF Core
            //services.AddDbContext<ExpenseDbContext>(options =>
            //    options.UseNpgsql(configuration.GetConnectionString("Postgres")));

            // Репозитории
            //services.AddScoped<IExpenseRepository, ExpenseRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();

            // Сервисы бизнес-логики
            //services.AddScoped<ExpenseService>();
            //services.AddScoped<UserService>();
            services.AddScoped<ITelegramBotService, TelegramBotService>();
            //services.AddScoped<IExpenseService, ExpenseService>();
            //services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IBotUpdateHandler, BotUpdateHandler>();

            var token = config.GetRequiredSection("Telegram").GetValue<string>("Token");
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(token!));

            return services;
        }
    }
}