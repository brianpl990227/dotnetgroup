using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BlogMicroservice.Domain.Models
{
    public class BlogPromoModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [StringLength(140, ErrorMessage = "Minimo 15 máximo 140 caracteres", MinimumLength = 15)]
        public string Description { get; set; }

        //Valor sin descuento
        [Range(1, 10000000000000000)]
        public int MainPrice { get; set; }
        //Valor promocional
        public int PromoPrice { get; set; }

        public string UrlImg { get; set; }

        //Listado de recomendaciones hechas por los usuarios
        public List<PromoRatingModel> PromoRatings { get; set; }

    }
}
