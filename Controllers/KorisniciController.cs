using System.Collections.Generic;
using AutoMapper;
using AutoPeda.Data;
using AutoPeda.Dtos;
using AutoPeda.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace AutoPeda.Controllers
{
    [Route("api/korisnici")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAutoPedaRepo _repository;

       public KorisniciController(IAutoPedaRepo repository, IMapper mapper)
       {
           _mapper = mapper;
           _repository = repository;
       }

       [HttpGet]
       public ActionResult<IEnumerable<KorisnikReadDto>> GetAllKorisnici()
       {
            var sviKorisnici = _repository.GetAllKorisnici();

            return Ok(_mapper.Map<IEnumerable<KorisnikReadDto>>(sviKorisnici));     
       }

        [HttpGet("{id}", Name="GetKorisnikById")]
        public ActionResult<KorisnikReadDto> GetKorisnikById(int id)
        {
                var korisnik = _repository.GetKorisnikById(id);

                return Ok(_mapper.Map<KorisnikReadDto>(korisnik));     
        }

       [HttpPost]
       public ActionResult<KorisnikReadDto> CreateKorisnik(KorisnikCreateDto korisnikCreateDto)
       {
           var korisnik = _mapper.Map<Korisnik>(korisnikCreateDto);

           _repository.CreateKorisnik(korisnik);
           _repository.SaveChanges();

            var korisnikReadDto = _mapper.Map<KorisnikReadDto>(korisnik);

            return Ok();

       }

       [HttpPut("{id}")]
       public ActionResult<Korisnik> UpdateKorisnik(int id, KorisnikUpdateDto korisnikUpdateDto)
       {
            var korisnikFromRepo = _repository.GetKorisnikById(id);

            if(korisnikFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(korisnikUpdateDto, korisnikFromRepo);

            _repository.SaveChanges();

            return NoContent();

       }

        [HttpPatch("{id}")]
        public ActionResult PartialKorisnikUpdate(int id, JsonPatchDocument<KorisnikUpdateDto> patchDocument)
        {
            var korisnikFromRepo = _repository.GetKorisnikById(id);
            if(korisnikFromRepo == null)
            {
                return NotFound();
            }

            var korisnikToPatch = _mapper.Map<KorisnikUpdateDto>(korisnikFromRepo);
            patchDocument.ApplyTo(korisnikToPatch, ModelState);

            if(!TryValidateModel(korisnikToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(korisnikToPatch, korisnikFromRepo);

            _repository.UpdateKorisnik(korisnikFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteKorisnik(int id)
        {
            
            var korisnik = _repository.GetKorisnikById(id);

            if(korisnik == null)
            {
                return NotFound();
            }

            _repository.DeleteKorisnik(korisnik);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}