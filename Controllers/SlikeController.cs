using System.Collections.Generic;
using AutoMapper;
using AutoPeda.Data;
using AutoPeda.Dtos;
using AutoPeda.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace AutoPeda.Controllers
{
    [Route("api/slike")]
    [ApiController]
    public class SlikeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAutoPedaRepo _repository;

       public SlikeController(IAutoPedaRepo repository, IMapper mapper)
       {
           _mapper = mapper;
           _repository = repository;
       }


        [HttpGet("{id}", Name="GetSlikaByProizvodId")]
        public ActionResult<Slika> GetSlikaByProizvodId(int id)
        {
                var slika = _repository.GetSlikaByProizvodId(id);

                return Ok(slika);     
        }

       [HttpPost]
       public ActionResult<Slika> CreateSlika(Slika slika)
       {

           _repository.CreateSlika(slika);
           _repository.SaveChanges();

            return Ok();

       }

        [HttpDelete("{id}")]
        public ActionResult DeleteSlika(Slika slika)
        {

            _repository.DeleteSlika(slika);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}