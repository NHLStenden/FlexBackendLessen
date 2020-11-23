using System.Collections.Generic;
using System.Linq;
using FlexBackendLessen.Repository;
using Microsoft.EntityFrameworkCore;

namespace FlexBackendLessen.Models
{
    public class ProductRepository :  GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(WebshopContext context) : base(context)
        {
        }


        public List<Product> GetProductWithCategories()
        {
            return _context.Products.Include(x => x.Category).ToList();
        }
    }
}
