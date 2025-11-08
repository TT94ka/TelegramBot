using Microsoft.Extensions.DependencyInjection;

namespace TelegramBot.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
    //    services.AddScoped<IExpenseService, ExpenseService>();
        return services;
    }
}
