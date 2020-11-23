using FlexBackendLessen.Models;

namespace FlexBackendLessen.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(WebshopContext context) : base(context)
        {
        }
    }
}
