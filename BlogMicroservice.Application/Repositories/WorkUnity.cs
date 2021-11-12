using BlogMicroservice.Application.Repositories.IRepositories;
using BlogMicroservice.Infraestruture;

namespace BlogMicroservice.Application.Repositories
{
    public class WorkUnity : IWorkUnity
    {
        /*Herramientas: 
         APPDbContext - Obj de tipo Interfaz contenido en IWorkUnity
         constructor
         */

        private readonly ApplicationDbContext _context;

        public IBlogPromoRepo BlogPromo { get; private set; }

        public IPromoRatingRepo PromoRating { get; private set; }

        public WorkUnity(ApplicationDbContext context)
        {
            _context = context;
            BlogPromo = new BlogPromoRepo(_context);
            PromoRating = new PromoRatingRepo(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveData()
        {
            _context.SaveChanges();
        }
    }
}
