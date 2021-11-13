using BlogMicroservice.Infraestruture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMicroservice.Application.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace BlogMicroservice.Application.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        internal DbSet<T> _dbSet;

        public RepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            
        }

        public async Task AddT(T entity)
        {
            await _dbSet.AddAsync(entity);   
        }

        public async Task<T> GetT(int id, string includeproperties = null)
        {
           return await _dbSet.FindAsync(id);  
        }

        public async Task<IEnumerable<T>> GetTAll(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, 
            string includeproperties = null)
        {
           //Objeto de tipo IQueryAble que usaremos para las validaciones
           IQueryable<T> query = _dbSet;

            //Si filter es diferente a null entonces haremos un select * from where filter sea igual a lo que estamos buscando
            if (filter != null)
            {
                query = query.Where(filter); 
            }

            //Si incluye props
            if (includeproperties != null)
            {
                foreach (var item in includeproperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item); 
                }
            }

            if (orderby != null)
            {
                return await orderby(query).ToListAsync(); //Ordenamos segun dato
            }
            //Lista solicitada
            return await query.ToListAsync(); 
        }

        public async Task<T> GetTFirst(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, string includeproperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeproperties != null)
            {
                foreach (var item in includeproperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            //Objeto 1 de la lista
            return await query .FirstOrDefaultAsync();
        }
        //Eliminar by id
        public async Task RemoveT(int id)
        {
            T entity = await _dbSet.FindAsync(id);
            await RemoveT(entity);
        }
        //Eliminar entidad - para implementar en Eliminar by id
        public async Task RemoveT(T entity)
        {
             _dbSet.Remove(entity);
        }
        //Eliminar lista
        public async Task RemoveRangeT(IEnumerable<T> entitylist)
        {
            _dbSet.RemoveRange(entitylist);
        }
    }
}
