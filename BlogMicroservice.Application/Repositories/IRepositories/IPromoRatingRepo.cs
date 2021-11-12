using BlogMicroservice.Domain.Models;
using System.Threading.Tasks;

namespace BlogMicroservice.Application.Repositories.IRepositories
{
    public interface IPromoRatingRepo : IRepositoryAsync<PromoRatingModel>
    {
        Task Update(PromoRatingModel promoRating);
    }
}
