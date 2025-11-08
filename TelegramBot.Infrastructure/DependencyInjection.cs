using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using TelegramBot.Infrastructure.Data;

namespace TelegramBot.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var token = config.GetRequiredSection("Telegram").GetValue<string>("Token");
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(token!));

        services.AddDbContext<ExpenseDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("DefaultConnection")));


        //services.AddScoped<IExpenseRepository, ExpenseRepository>();

        return services;
    }
}