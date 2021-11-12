using BlogMicroservice.Domain.Models;
using System.Collections.Generic;


namespace BlogMicroservice.Domain.Dtos
{
    public class BlogPromoDto
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        public string Description { get; set; }
        public int MainPrice { get; set; }
        public int PromoPrice { get; set; }
        public string UrlImg { get; set; }
        public List<PromoRatingModel> PromoRatings { get; set; }
    }
}
