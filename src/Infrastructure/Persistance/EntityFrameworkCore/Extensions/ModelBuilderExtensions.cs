using Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.EntityFrameworkCore.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder BuildCategories(this ModelBuilder builder)
        {
            builder.Entity<Category>(b =>
            {
                b.ToTable("AppCategories");
                b.HasKey(c => c.Id);
                b.Property(c => c.Name).IsRequired().HasMaxLength(Category.NameMaxLength);
                b.Property(c => c.Description).IsRequired().HasMaxLength(Category.DescriptionMaxLength);

                b.HasIndex(c => c.Id);
            });

            return builder;
        }
    }
}
