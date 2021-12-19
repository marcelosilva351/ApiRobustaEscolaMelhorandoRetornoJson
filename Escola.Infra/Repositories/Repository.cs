using Escola.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApiContext _context;

        public Repository(ApiContext context)
        {
            _context = context;
        }

        public async Task Create(T entityAdd)
        {
            _context.Set<T>().Add(entityAdd);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(T EntityDelete)
        {
            _context.Set<T>().Remove(EntityDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> Get()
        {
            var entitys = await _context.Set<T>().ToListAsync();
            if(entitys != null)
            {
                return entitys;
            }
            return null;
        }

        public async Task<T> GetById(int id)
        {
            var entityId = await _context.Set<T>().FindAsync(id);
            if(entityId != null)
            {
                return entityId;
            }
            return null;
        }

        public async Task Update(T entityUpdate)
        {
            _context.Set<T>().Update(entityUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
