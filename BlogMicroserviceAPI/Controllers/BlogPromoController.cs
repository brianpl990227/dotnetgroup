using AutoMapper;
using BlogMicroservice.Application.Repositories.IRepositories;
using BlogMicroservice.Domain.Dtos;
using BlogMicroservice.Domain.Models;
using BlogMicroservice.Infraestruture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogMicroservice.API.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPromoController : ControllerBase
    {
        /*
            Herramientas para trabajar:
            WorkUnity - Por implementar.
         */

        private readonly ApplicationDbContext _context;
        private readonly IWorkUnity _workUnity;
        private readonly IMapper _mapper;
        protected ResponseDto _response;

        public BlogPromoController(ApplicationDbContext context, 
                                             IWorkUnity workUnity,
                                             IMapper mapper)
        {
            _context = context;
            _workUnity = workUnity;
            _mapper = mapper;
            _response = new ResponseDto();
        } 

        
        //Get: api/blogpromo/5
        [HttpGet("{id}")] //Por medio de WorkUnity
        public async Task<BlogPromoDto> GetPromoById(int id)
        {
            //Include por medio de EF para listar los comentarios y estrellas
            await _context.BlogPromo.Include(x => x.PromoRatings).ToListAsync();
            var blogPromo = await _workUnity.BlogPromo.GetT(id);
            return _mapper.Map<BlogPromoDto>(blogPromo);
        }

        
        [HttpGet]//Get: api/blogpromo - por medio de WorkUnity 
        public async Task<ActionResult<IEnumerable<BlogPromoDto>>> GetPromosList()
        {
            try
            {
                var blogList = await _workUnity.BlogPromo.GetTAll(includeproperties: "PromoRatings");
                _response.Result = blogList;
                _response.DisplayMessage = "Blog List";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        [HttpPost]//Por medio de Workunity.
        public async Task<BlogPromoDto> AddPromo(BlogPromoDto blogPromoDto)
        {
            var blogPromo = _mapper.Map<BlogPromoDto, BlogPromoModel>(blogPromoDto);
            await _workUnity.BlogPromo.AddT(blogPromo);
            _workUnity.SaveData();
            return _mapper.Map<BlogPromoModel, BlogPromoDto>(blogPromo);  
        }

        [HttpPut("{id}")]//Por medio de WorkUnity
        public async Task<BlogPromoDto> UpdatePromo(int id, BlogPromoDto blogPromoDto)
        {
            BlogPromoModel blogPromo = _mapper.Map<BlogPromoDto, BlogPromoModel>(blogPromoDto);
            if (id==blogPromo.Id)
            {
                await _workUnity.BlogPromo.Update(blogPromo);
            }
            return _mapper.Map<BlogPromoModel, BlogPromoDto>(blogPromo);
        }


        [HttpDelete]//Por medio de workUnity + Find del AppDbContext
        public async Task<bool> DeletePromo(int id)
        {
            try
            {
                BlogPromoModel blogPromo = await _context.BlogPromo.FindAsync(id);
                if (blogPromo!=null)
                {
                    await _workUnity.BlogPromo.RemoveT(blogPromo);
                    _workUnity.SaveData();
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {

                return false;
            }
            return true;            
        }

        private bool BlogpromoExists(int id)
        {
            return true;
        }
 
    }
}
