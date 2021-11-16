using Microsoft.Extensions.DependencyInjection;

namespace CodingChallenge.Application
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICreditLineCalculator, CreditLineCalculator>();
            
            return services;
        }
    }
}