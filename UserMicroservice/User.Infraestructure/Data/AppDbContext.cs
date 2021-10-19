using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.DbModel;
using System.Reflection;

namespace User.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<AppUser> AppUsers { get; set; }

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
              
        }

    

    }
}
