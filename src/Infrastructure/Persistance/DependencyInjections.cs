using Domain.Entities.Categories;
using Domain.Shareds.Uow;
using Microsoft.Extensions.DependencyInjection;
using Persistance.EntityFrameworkCore;
using Persistance.EntityFrameworkCore.Repositories.Categories;
using Persistance.EntityFrameworkCore.Uow;

namespace Persistance
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services)
            => services.AddDbContext<LibraryDbContext>();
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
            => services.AddScoped<IUnitOfWork, UnitOfWork>();
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            return services;
        }
    }
}
