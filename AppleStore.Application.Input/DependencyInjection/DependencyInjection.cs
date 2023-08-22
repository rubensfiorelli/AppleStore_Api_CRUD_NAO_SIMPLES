using AppleStore.Application.Input.Repositories;
using AppleStore.Application.Input.Services;
using AppleStore.Application.Output.Repositories;
using AppleStore.Application.Output.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppleStore.Application.Input.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            services.AddScoped(typeof(ICategoryReadService), typeof(CategoryReadService));
            services.AddScoped(typeof(ICategoryWriteService), typeof(CategoryWriteService));
            services.AddScoped(typeof(IProductReadService), typeof(ProductReadService));
            services.AddScoped(typeof(IProductWriteService), typeof(ProductWriteService));


            return services;
        }
    }
}
