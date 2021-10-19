using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Infraestructure.Services.CacheService
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache cache;

        public CacheService(IMemoryCache _cache) => cache = _cache;
       

        public bool CountLoginFailed(string email)
        {
            int cont;
            //Pregunto si está ese Key en mi cache, por alguna razon solo guarda el tipo
            //de dato de la variable que le sigue al out
            if (!cache.TryGetValue(email, out cont))
            {
                //Creo un key con el email del usuario y le asigno el valor uno 
                //que representa el primer intento fallido
                cache.Set(email, 1, TimeSpan.FromMinutes(3));
                cont = 1;
            }
            else
            {
                //Si ya tengo ese Key le sumo 1 al intento fallido
                cache.Set(email, (cache.Get<int>(email) + 1), TimeSpan.FromMinutes(3));

                //Obtengo la cantidad de veces que ha fallado ese Key
                cont = cache.Get<int>(email);

                //Si ha fallado 3 veces devuelvo true para bloquear la cuenta
                if (cont >= 3)
                {
                    return true;
                }
            }

            return false;

        }

    }
}
