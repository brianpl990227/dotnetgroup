namespace BlogMicroservice.Domain.Dtos
{
    public class PostPutPromoRatingDto
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string Feedback { get; set; }
        public int BlogPromoId { get; set; }
        public int UserAppId { get; set; }
    }
}
