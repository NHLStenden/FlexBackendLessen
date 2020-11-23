using System.Collections.Generic;
using FlexBackendLessen.Models;

namespace FlexBackendLessen.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProductWithCategories();
    }
}
