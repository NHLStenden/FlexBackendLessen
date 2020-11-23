using System.Collections.Generic;

namespace FlexBackendLessen.Repository
{
    public interface IRepository<T>
    {
        public List<T> Get();
        public T Get(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
