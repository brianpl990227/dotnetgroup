using System;

namespace BlogMicroservice.Application.Repositories.IRepositories
{
    public interface IWorkUnity : IDisposable //Liberación de objs sin uso
    {
        IBlogPromoRepo BlogPromo { get; }
        IPromoRatingRepo PromoRating { get; }   
        void SaveData();
    }
}
