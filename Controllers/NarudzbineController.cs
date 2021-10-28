using System.Collections.Generic;
using AutoMapper;
using AutoPeda.Data;
using AutoPeda.Dtos;
using AutoPeda.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace AutoPeda.Controllers
{
    [Route("api/narudzbine")]
    [ApiController]
    public class NarudzbineController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAutoPedaRepo _repository;

       public NarudzbineController(IAutoPedaRepo repository, IMapper mapper)
       {
           _mapper = mapper;
           _repository = repository;
       }

       [HttpGet]
       public ActionResult<IEnumerable<NarudzbinaReadDto>> GetAllNarudzbine()
       {
            var sveNarudzbine = _repository.GetAllNarudzbina();

            return Ok(_mapper.Map<IEnumerable<NarudzbinaReadDto>>(sveNarudzbine));     
       }

        [HttpGet("{id}", Name="GetNarudzbinaById")]
        public ActionResult<NarudzbinaReadDto> GetNarudzbinaById(int id)
        {
                var narudzbine = _repository.GetNarudzbinaById(id);

                return Ok(_mapper.Map<NarudzbinaReadDto>(narudzbine));     
        }

       [HttpPost]
       public ActionResult<NarudzbinaReadDto> CreateNarudzbina(NarudzbinaCreateDto narudzbinaCreateDto)
       {
           var narudzbina = _mapper.Map<Narudzbina>(narudzbinaCreateDto);

           _repository.CreateNarudzbina(narudzbina);
           _repository.SaveChanges();

            var narudzbinaReadDto = _mapper.Map<NarudzbinaReadDto>(narudzbina);

            return Ok();

       }

        [HttpDelete("{id}")]
        public ActionResult DeleteNarudzbina(int id)
        {
            
            var narudzbina = _repository.GetNarudzbinaById(id);

            if(narudzbina == null)
            {
                return NotFound();
            }

            _repository.DeleteNarudzbina(narudzbina);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}