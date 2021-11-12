using BlogMicroservice.Application.Repositories.IRepositories;
using BlogMicroservice.Domain.Models;
using BlogMicroservice.Infraestruture;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMicroservice.Application.Repositories
{
    public class PromoRatingRepo : RepositoryAsync<PromoRatingModel>, IPromoRatingRepo
    {
        /*
         Herramientas a utilizar: ApplicationDbContext y un constructor
         base para extender del constructor de applicationdbcontext
         */
        private readonly ApplicationDbContext _context;
        public PromoRatingRepo(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task Update(PromoRatingModel promoRating)
        {
            //var = al Rating recibido por parametro
            var promoRatingDb = _context.RatingPromo.FirstOrDefault(x => x.Id == promoRating.Id);
            if (promoRatingDb!=null)
            {
                promoRatingDb.Stars = promoRating.Stars;
                promoRatingDb.Feedback = promoRating.Feedback;
                await _context.SaveChangesAsync();
            }
        }
    }
}
