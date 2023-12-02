using FundManagementSystem.Application.Contracts.Persistence;
using FundManagementSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManagementSystem.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<FMSDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FMSConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            return services;
        }
    }
}
