
using System.Collections.Generic;

namespace ProjectTobi.Interface.Repository
{
    public interface ICrudRepository<T> where T : class
    {
        void Add(T obj);
        void Update(int id, T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
