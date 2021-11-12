using BlogMicroservice.Infraestruture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogMicroservice.Services
{
    public static class ServiceExtensions
    {
        public static void AddServiceSqlServer(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Conexion mediante puertos a bd remota"));
        }
    }
}
