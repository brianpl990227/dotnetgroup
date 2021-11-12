using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogMicroservice.Application.Repositories.IRepositories
{
    public interface IRepositoryAsync<T> where T : class
    {
        //Metodos a implementar

        //Obtener Promo o Rating por id
        /*1*/ Task<T> GetT(int id, string includeproperties = null);

        //Obtener Lista de T IENumerable con consultas Linq
        /*2*/ Task<IEnumerable<T>> GetTAll(Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                string includeproperties = null
                );
        //consultaremos por el primero que tenga X propiedad
        /*3*/ Task<T> GetTFirst(
                Expression<Func<T, bool>> filter = null,
                string includeproperties = null
                  );
        //Agregar
        /*4*/ Task AddT(T entity);

        //Remove por id
        /*5*/ Task RemoveT(int id);

        //Remove T = Clase
        /*6*/ Task RemoveT(T entity);

        //Remove por rango
        /*7*/ Task RemoveRangeT(IEnumerable<T> entitylist);
    }
}
