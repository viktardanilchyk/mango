﻿using CodingChallenge.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CodingChallenge.Persistence
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterPersistence(this IServiceCollection services)
        {
            services.AddDbContext<CreditLineDbContext>(options =>
            {
                options.UseInMemoryDatabase("CreditLineDB");
            });

            services.AddTransient<ICreditLineRepository, CreditLineRequestRepository>();
            
            return services;
        }
    }
}