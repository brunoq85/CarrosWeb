using CarrosWeb.API.Services;
using CarrosWeb.Core.Interfaces;
using CarrosWeb.Infra.Data.Context;
using CarrosWeb.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CarrosWeb.Infra.IoC
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection AddConfigurationServices(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<ICarroRepository, CarroRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Registrando o Serilog.ILogger para ser injetado
            services.AddSingleton<Serilog.ILogger>(Log.Logger);

            // Registrando o LoggerService
            services.AddScoped<LoggerService>();

            return services;
        }
    }
}
