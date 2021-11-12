using BlogMicroservice.Domain.Models;
using System.Threading.Tasks;

namespace BlogMicroservice.Application.Repositories.IRepositories
{
    public interface IBlogPromoRepo : IRepositoryAsync<BlogPromoModel>
    {
        Task Update(BlogPromoModel blogPromo);
    }
}
