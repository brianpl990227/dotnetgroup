using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services.CacheService
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache cache;

        public CacheService(IMemoryCache _cache)
        {
            cache = _cache;
        }

        public bool CountLoginFailed(string email)
        {
            int cont;
            if (!cache.TryGetValue(email, out cont))
            {
                cache.Set(email, 1, TimeSpan.FromSeconds(5));
                cont = 1;
            }
            else
            {
                cache.Set(email, (cache.Get<int>(email) + 1), TimeSpan.FromSeconds(500));
                cont = cache.Get<int>(email);
                if (cont >= 3)
                {
                    return true;
                }
            }

            return false;

        }

    }
}
