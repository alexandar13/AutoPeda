using System.Collections.Generic;
using AutoMapper;
using AutoPeda.Data;
using AutoPeda.Dtos;
using AutoPeda.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace AutoPeda.Controllers
{
    [Route("api/marke")]
    [ApiController]
    public class MarkeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAutoPedaRepo _repository;

       public MarkeController(IAutoPedaRepo repository, IMapper mapper)
       {
           _mapper = mapper;
           _repository = repository;
       }

       [HttpGet]
       public ActionResult<IEnumerable<Marka>> GetAllMarke()
       {
            var sveMarke = _repository.GetAllMarka();

            return Ok(_mapper.Map<IEnumerable<MarkaReadDto>>(sveMarke));     
       } 

        [HttpGet("{id}", Name="GetMarkaById")]
        public ActionResult<Marka> GetMarkaById(string id)
        {
                var marka = _repository.GetMarkaById(id);

                return Ok(_mapper.Map<MarkaReadDto>(marka));     
        }

       [HttpPost]
       public ActionResult<Marka> CreateMarka(Marka marka)
       {
           _repository.CreateMarka(marka);
           _repository.SaveChanges();

            return Ok();

       }

        [HttpDelete("{id}")]
        public ActionResult DeleteMarka(string id)
        {
            
            var marka = _repository.GetMarkaById(id);

            if(marka == null)
            {
                return NotFound();
            }

            _repository.DeleteMarka(marka);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}