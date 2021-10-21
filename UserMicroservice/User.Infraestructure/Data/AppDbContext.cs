using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using User.Infraestructure.Data.DbModels;

namespace User.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<FailUserLogin> FailUserLogin { get; set; }
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
              
        }

    

    }
}
