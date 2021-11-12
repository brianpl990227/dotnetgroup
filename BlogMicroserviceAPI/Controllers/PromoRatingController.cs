using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BlogMicroservice.Application.Repositories.IRepositories;
using BlogMicroservice.Domain.Dtos;
using BlogMicroservice.Domain.Models;
using System.Threading.Tasks;
using System;
using BlogMicroservice.Infraestruture;
using Microsoft.EntityFrameworkCore;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogMicroservice.API.Controllers
{
    [Route("api/blogpromo/{blogPromoId:int}/promoRating")]
    [ApiController]
    public class PromoRatingController : ControllerBase
    {
        /*
            Herramientas para trabajar:
            WorkUnity - Por implementar.
         */

        private readonly ApplicationDbContext _context;
        private readonly IWorkUnity _workUnity;
        private readonly IMapper _mapper;
        protected ResponseDto _response;

        public PromoRatingController(ApplicationDbContext context,
                                     IWorkUnity workUnity,
                                     IMapper mapper)
        {
            //inicializar herramientas a utilizar
            _context = context;
            _workUnity = workUnity;
            _mapper = mapper;
            _response = new ResponseDto();
        }


        [HttpPost]//Por medio de la unidad de trabajo
        public async Task<PostPutPromoRatingDto> AddRating(PostPutPromoRatingDto promoRatingDto)
        {
            var promoRating = _mapper.Map<PostPutPromoRatingDto, PromoRatingModel>(promoRatingDto);
            await _workUnity.PromoRating.AddT(promoRating);
            _workUnity.SaveData();
            return _mapper.Map<PromoRatingModel, PostPutPromoRatingDto>(promoRating);
        }


        [HttpGet]//Usando unidad de trabajo
        public async Task<ActionResult<List<GetPromoRatingDto>>> GetRatings(int blogPromoId)
        {
            var existBlogPromo = await _context.BlogPromo.AnyAsync(x=>x.Id == blogPromoId);
            if (!existBlogPromo)
            {
                return NotFound();
            }
            else 
            {
                   var listRating = await _context.RatingPromo.Where(x=>x.BlogPromoId == blogPromoId).ToListAsync();
                   return _mapper.Map<List<GetPromoRatingDto>>(listRating);
            }
        }


        [HttpPut("{id}")]//Por medio de unidad de trabajo, obteniendo obj mediante id
        public async Task<PostPutPromoRatingDto> UpdateRating(int id, PostPutPromoRatingDto promoRatingDto)
        {
            var promoRating = _mapper.Map<PostPutPromoRatingDto, PromoRatingModel>(promoRatingDto);
            try
            {
                if (id==promoRating.Id)
                {
                    await _workUnity.PromoRating.Update(promoRating); 
                }
            }
            catch (Exception ex)
            {
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return _mapper.Map<PromoRatingModel, PostPutPromoRatingDto>(promoRating);
        }

    }
}
