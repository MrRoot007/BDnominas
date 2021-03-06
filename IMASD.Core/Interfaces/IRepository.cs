using Nomina2018.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nomina2018.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
