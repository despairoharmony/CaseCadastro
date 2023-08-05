using CaseCadastro.Domain.Interfaces;
using CaseCadastro.Domain.Models;
using CaseCadastro.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CaseCadastro.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CadastroContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnityWork, UnityWork>();
            services.AddScoped<ICadastroRepository, CadastroRepository>();

            return services;
        }

    }
}
