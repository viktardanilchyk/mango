using CodingChallenge.Application.CreditLineService;
using Microsoft.Extensions.DependencyInjection;

namespace CodingChallenge.Application
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICreditLineService, CreditLineService.CreditLineService>();
            
            return services;
        }
    }
}