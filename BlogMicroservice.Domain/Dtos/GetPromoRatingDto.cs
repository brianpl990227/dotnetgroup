using BlogMicroservice.Domain.Models;

namespace BlogMicroservice.Domain.Dtos
{
    public class GetPromoRatingDto
    {
     
        //Dto para óbtención de data en metodos Get
        public int Stars { get; set; }
        public string Feedback { get; set; }
        public int? UserAppId { get; set; }
    }
}
