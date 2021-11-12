using BlogMicroservice.Application.Repositories.IRepositories;
using BlogMicroservice.Domain.Models;
using BlogMicroservice.Infraestruture;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMicroservice.Application.Repositories
{
    public class BlogPromoRepo : RepositoryAsync<BlogPromoModel>, IBlogPromoRepo
    {
        /*
         Herramientas a utilizar: ApplicationDbContext y un constructor
         base para extender del constructor de applicationdbcontext
         */
        private readonly ApplicationDbContext _context;
        public BlogPromoRepo(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
        public async Task Update(BlogPromoModel blogPromo)
        {
            //var = al BlogPromo recibido por parametro
            var blogPromoDb = _context.BlogPromo.FirstOrDefault(x => x.Id == blogPromo.Id);
            if (blogPromoDb != null)
            {
                //Update de la información de promo
                if (blogPromo.UrlImg != null)
                {
                    blogPromoDb.UrlImg = blogPromo.UrlImg;
                }
                blogPromoDb.Name = blogPromo.Name;
                blogPromoDb.Description = blogPromo.Description;
                blogPromoDb.MainPrice = blogPromo.MainPrice;
                blogPromoDb.PromoPrice = blogPromo.PromoPrice;
                await _context.SaveChangesAsync();

            }
            
        }
    }
}
