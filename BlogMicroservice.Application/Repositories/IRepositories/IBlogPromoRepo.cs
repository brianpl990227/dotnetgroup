using BlogMicroservice.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogMicroservice.Application.Repositories.IRepositories
{
    public interface IBlogPromoRepo : IRepositoryAsync<BlogPromoModel>
    {
        Task Update(BlogPromoModel blogPromo);

        Task<ActionResult<BlogPromoModel>> GetBlogPromo(int id);
    }
}
