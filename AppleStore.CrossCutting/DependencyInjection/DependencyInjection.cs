using AppleStore.Data.Configuration;
using AppleStore.Data.RepositoriesImplemented;
using AppleStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppleStore.CrossCutting.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastrucutre(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddRepositories();

            services.AddDbContextPool<ApplicationDbContext>(opts => opts
                    .UseMySql(configuration.GetConnectionString("DbConnection"),
                     ServerVersion.AutoDetect(configuration.GetConnectionString("DbConnection")),
                     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICategoryReadRepository), typeof(CategoryReadRepository));
            services.AddScoped(typeof(ICategoryWriteRepository), typeof(CategoryWriteRepository));
            services.AddScoped(typeof(IProductReadRepository), typeof(ProductReadRepository));
            services.AddScoped(typeof(IProductWriteRepository), typeof(ProductWriteRepository));



            return services;
        }
    }
}
