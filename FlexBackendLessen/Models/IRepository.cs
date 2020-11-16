using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FlexBackendLessen.Models
{
    public interface IRepository<T>
    {
        public List<T> Get();
        public T Get(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }

    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProductWithCategories();
    }

    public interface ICategoryRepository : IRepository<Category>
    {

    }

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly WebshopContext _context;

        public GenericRepository(WebshopContext context)
        {
            _context = context;
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }

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

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(WebshopContext context) : base(context)
        {
        }
    }


}
