using BlogMicroservice.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMicroservice.Infraestruture
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BlogPromoModel> BlogPromo { get; set; }
        public DbSet<PromoRatingModel> RatingPromo { get; set; }
    }
}
