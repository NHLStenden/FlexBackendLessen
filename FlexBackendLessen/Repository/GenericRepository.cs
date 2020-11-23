using System;
using System.Collections.Generic;
using System.Linq;
using FlexBackendLessen.Models;

namespace FlexBackendLessen.Repository
{
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
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entityToRemove = _context.Find<T>(id);
            _context.Set<T>().Remove(entityToRemove);
            _context.SaveChanges();
        }
    }
}
