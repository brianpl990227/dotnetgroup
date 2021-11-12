using AutoMapper;
using BlogMicroservice.Domain.Dtos;
using BlogMicroservice.Domain.Models;

namespace BlogMicroservice.API
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            /*
             Mapeo entre modelos y Dto
             */
            var mapping = new MapperConfiguration(config =>
            {
                //Mapeo de Dto a Modelo y viceversa
                config.CreateMap<BlogPromoDto, BlogPromoModel>();
                config.CreateMap<BlogPromoModel, BlogPromoDto>();
                config.CreateMap<GetPromoRatingDto, PromoRatingModel>();
                config.CreateMap<PromoRatingModel, GetPromoRatingDto>();
                config.CreateMap<PostPutPromoRatingDto, PromoRatingModel>();
                config.CreateMap<PromoRatingModel, PostPutPromoRatingDto>();
            });

            return mapping;
        }
    }
}
