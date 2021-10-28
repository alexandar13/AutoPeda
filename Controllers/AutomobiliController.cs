using System.Collections.Generic;
using AutoMapper;
using AutoPeda.Data;
using AutoPeda.Dtos;
using AutoPeda.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace AutoPeda.Controllers
{
    [Route("api/automobili")]
    [ApiController]
    public class AutomobiliController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAutoPedaRepo _repository;

       public AutomobiliController(IAutoPedaRepo repository, IMapper mapper)
       {
           _mapper = mapper;
           _repository = repository;
       }

       [HttpGet]
       public ActionResult<IEnumerable<AutoReadDto>> GetAllAutomobili()
       {
            var sviAutomobili = _repository.GetAllAutomobili();

            return Ok(_mapper.Map<IEnumerable<AutoReadDto>>(sviAutomobili));     
       }
 
        [HttpGet("{id}", Name="GetAutoById")]
        public ActionResult<AutoReadDto> GetAutomobilById(int id)
        {
                var automobil = _repository.GetAutoById(id);

                return Ok(_mapper.Map<AutoReadDto>(automobil));     
        }

       [HttpPost]
       public ActionResult<AutoReadDto> CreateAuto(AutoCreateDto autoCreateDto)
       {
           var auto = _mapper.Map<Auto>(autoCreateDto);

           _repository.CreateAuto(auto);
           _repository.SaveChanges();

            var autoReadDto = _mapper.Map<AutoReadDto>(auto);

            return Ok();

       }

       [HttpPut("{id}")]
       public ActionResult<Auto> UpdateAuto(int id, AutoUpdateDto autoUpdateDto)
       {
            var autoFromRepo = _repository.GetAutoById(id);

            if(autoFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(autoUpdateDto, autoFromRepo);

            _repository.SaveChanges();

            return NoContent();

       }

        [HttpPatch("{id}")]
        public ActionResult PartialAutoUpdate(int id, JsonPatchDocument<AutoUpdateDto> patchDocument)
        {
            var autoFromRepo = _repository.GetAutoById(id);
            if(autoFromRepo == null)
            {
                return NotFound();
            }

            var autoToPatch = _mapper.Map<AutoUpdateDto>(autoFromRepo);
            patchDocument.ApplyTo(autoToPatch, ModelState);

            if(!TryValidateModel(autoToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(autoToPatch, autoFromRepo);

            _repository.UpdateAuto(autoFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAuto(int id)
        {
            
            var auto = _repository.GetAutoById(id);

            if(auto == null)
            {
                return NotFound();
            }

            _repository.DeleteAuto(auto);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}