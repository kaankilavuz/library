using Domain.Entities.Categories;

namespace Persistance.EntityFrameworkCore.Repositories.Categories
{
    public class EfCoreCategoryRepository : EfCoreRepositoryBase<Category, Guid>, ICategoryRepository
    {
        public EfCoreCategoryRepository(LibraryDbContext context) : base(context)
        {

        }
    }
}
