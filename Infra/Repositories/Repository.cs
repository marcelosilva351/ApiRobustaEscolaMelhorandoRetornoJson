using Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> Get()
        {
            var entity = await _context.Set<T>().ToListAsync();
            if(entity == null)
            {
                return null;
            }
            return entity;

        }

        public async Task<T> GetId(int id)
        {
           var entity =  await _context.Set<T>().FindAsync(id);
            if(entity == null)
            {
                return null;
            }
            return entity;

        }

        public  async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
