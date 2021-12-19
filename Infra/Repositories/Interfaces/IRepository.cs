using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<T> GetId(int id);
        Task<List<T>> Get();

        
       


    }
}
