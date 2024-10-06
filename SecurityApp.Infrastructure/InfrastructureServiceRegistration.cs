using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecurityApp.Application.Contracts.Persistence;
using SecurityApp.Infrastructure.Persistence;
using SecurityApp.Infrastructure.Repositories;

namespace SecurityApp.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfraestructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SecurityAppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));  
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<ICuidadoRepository, CuidadoRepository>();
            services.AddScoped<ICuidadorRepository, CuidadorRepository>();
            services.AddScoped<IExamenRepository, ExamenRepository>();
            services.AddScoped<IVacunaRepository, VacunaRepository>();
            
            return services;

        }

    }
}
