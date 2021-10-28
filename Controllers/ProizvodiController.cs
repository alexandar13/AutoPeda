using System.Collections.Generic;
using AutoMapper;
using AutoPeda.Data;
using AutoPeda.Dtos;
using AutoPeda.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace AutoPeda.Controllers
{
    [Route("api/proizvodi")]
    [ApiController]
    public class ProizvodiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAutoPedaRepo _repository;

       public ProizvodiController(IAutoPedaRepo repository, IMapper mapper)
       {
           _mapper = mapper;
           _repository = repository;
       }

       [HttpGet]
       public ActionResult<IEnumerable<ProizvodReadDto>> GetAllProizvodi()
       {
            var sviProizvodi = _repository.GetAllProizvod();

            return Ok(_mapper.Map<IEnumerable<ProizvodReadDto>>(sviProizvodi));     
       }

        [HttpGet("{id}", Name="GetProizvodById")]
        public ActionResult<ProizvodReadDto> GetProizvodById(int id)
        {
                var proizvod = _repository.GetProizvodById(id);

                return Ok(_mapper.Map<ProizvodReadDto>(proizvod));     
        }

       [HttpPost]
       public ActionResult<ProizvodReadDto> CreateProizvod(ProizvodCreateDto proizvodCreateDto)
       {
           var proizvod = _mapper.Map<Proizvod>(proizvodCreateDto);

           _repository.CreateProizvod(proizvod);
           _repository.SaveChanges();

            var proizvodReadDto = _mapper.Map<ProizvodReadDto>(proizvod);

            return Ok();

       }

       [HttpPut("{id}")]
       public ActionResult<Proizvod> UpdateProizvod(int id, ProizvodUpdateDto proizvodUpdateDto)
       {
            var proizvodFromRepo = _repository.GetProizvodById(id);

            if(proizvodFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(proizvodUpdateDto, proizvodFromRepo);

            _repository.SaveChanges();

            return NoContent();

       }

        [HttpPatch("{id}")]
        public ActionResult PartialProizvodUpdate(int id, JsonPatchDocument<ProizvodUpdateDto> patchDocument)
        {
            var proizvodFromRepo = _repository.GetProizvodById(id);
            if(proizvodFromRepo == null)
            {
                return NotFound();
            }

            var proizvodToPatch = _mapper.Map<ProizvodUpdateDto>(proizvodFromRepo);
            patchDocument.ApplyTo(proizvodToPatch, ModelState);

            if(!TryValidateModel(proizvodToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(proizvodToPatch, proizvodFromRepo);

            _repository.UpdateProizvod(proizvodFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProizvod(int id)
        {
            
            var proizvod = _repository.GetProizvodById(id);

            if(proizvod == null)
            {
                return NotFound();
            }

            _repository.DeleteProizvod(proizvod);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}