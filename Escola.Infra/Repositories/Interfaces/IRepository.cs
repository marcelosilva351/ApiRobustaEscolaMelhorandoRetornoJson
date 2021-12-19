using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entityAdd);
        Task Update(T entityUpdate);
        Task Delete(T EntityDelete);
        Task<T> GetById(int id);
        Task<List<T>> Get();

      

    }
}
