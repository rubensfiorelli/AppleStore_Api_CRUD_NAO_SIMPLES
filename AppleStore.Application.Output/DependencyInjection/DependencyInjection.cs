using Microsoft.Extensions.DependencyInjection;

namespace AppleStore.Application.Output.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationOutput(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            //services.AddScoped(typeof(IProdutoRepository), typeof(ProdutoRepository));
            //services.AddScoped(typeof(ICategoriaReository), typeof(CategoriaRepository));

            return services;
        }
    }
}
