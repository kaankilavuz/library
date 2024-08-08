using Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistance.EntityFrameworkCore.Extensions;
using Persistance.EntityFrameworkCore.Interceptors;

namespace Persistance.EntityFrameworkCore
{
    public class LibraryDbContext : DbContext
    {
        #region db sets
        public DbSet<Category> AppCategories { get; init; }
        #endregion
        private IConfiguration Configuration { get; }
        public LibraryDbContext(
            DbContextOptions<LibraryDbContext> options,
            IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"))
                .AddInterceptors(new UserAndTimeStampSaveChangesInterceptor());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildCategories();
            base.OnModelCreating(modelBuilder);
        }
    }
}
