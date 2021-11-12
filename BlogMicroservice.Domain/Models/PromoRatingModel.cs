using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlogMicroservice.Domain.Models
{
    public class PromoRatingModel
    {
        [Key]
        public int Id { get; set; }        
        public int Stars { get; set; } 
        public string Feedback { get; set; }
        //Propiedad para asignarle un usuario al comentario
        public int BlogPromoId { get; set; }

        [ForeignKey("BlogPromoId")]
        public BlogPromoModel BlogPromo { get; set; }
        public int? UserAppId { get; set; }  
    }
}
