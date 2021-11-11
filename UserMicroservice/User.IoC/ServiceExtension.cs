using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application;
using User.Application.Auth;
using User.Domain.Login;
using User.Domain.Token;
using User.Domain.User;
using User.Infraestructure.Data;
using User.Infraestructure.Repositories;

namespace User.IoC
{
    public static class ServiceExtension
    {
        public static void AddServiceExtension(this IServiceCollection services)
        {
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<ITokenRepository, TokenRepository>();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddServicePostgreSQL(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql("Host=127.0.0.1;Port=5432;Database=UserMicroservice;User Id=postgres;Password=9902;");
            });
        }

     
    } 
}
