using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services) =>
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjections).Assembly));

        public static IServiceCollection AddMapper(this IServiceCollection services) =>
            services.AddAutoMapper(config => config.AddMaps(typeof(DependencyInjections).Assembly));
    }
}
