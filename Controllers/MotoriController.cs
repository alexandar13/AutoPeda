using System.Collections.Generic;
using AutoMapper;
using AutoPeda.Data;
using AutoPeda.Dtos;
using AutoPeda.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace AutoPeda.Controllers
{
    [Route("api/motori")]
    [ApiController]
    public class MotoriController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAutoPedaRepo _repository;

       public MotoriController(IAutoPedaRepo repository, IMapper mapper)
       {
           _mapper = mapper;
           _repository = repository;
       }

       [HttpGet]
       public ActionResult<IEnumerable<MotorReadDto>> GetAllMotori()
       {
            var sviMotori = _repository.GetAllMotor();

            return Ok(_mapper.Map<IEnumerable<MotorReadDto>>(sviMotori));     
       }

        [HttpGet("{id}", Name="GetMotorById")]
        public ActionResult<MotorReadDto> GetMotorById(int id)
        {
                var motor = _repository.GetMotorById(id);

                return Ok(_mapper.Map<MotorReadDto>(motor));     
        }

       [HttpPost]
       public ActionResult<MotorReadDto> CreateMotor(MotorCreateDto motorCreateDto)
       {
           var motor = _mapper.Map<Motor>(motorCreateDto);

           _repository.CreateMotor(motor);
           _repository.SaveChanges();

            var motorReadDto = _mapper.Map<MotorReadDto>(motor);

            return Ok();

       }

       [HttpPut("{id}")]
       public ActionResult<Motor> UpdateMotor(int id, MotorUpdateDto motorUpdateDto)
       {
            var motorFromRepo = _repository.GetMotorById(id);

            if(motorFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(motorUpdateDto, motorFromRepo);

            _repository.SaveChanges();

            return NoContent();

       }

        [HttpPatch("{id}")]
        public ActionResult PartialMotorUpdate(int id, JsonPatchDocument<MotorUpdateDto> patchDocument)
        {
            var motorFromRepo = _repository.GetMotorById(id);
            if(motorFromRepo == null)
            {
                return NotFound();
            }

            var motorToPatch = _mapper.Map<MotorUpdateDto>(motorFromRepo);
            patchDocument.ApplyTo(motorToPatch, ModelState);

            if(!TryValidateModel(motorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(motorToPatch, motorFromRepo);

            _repository.UpdateMotor(motorFromRepo);

            _repository.SaveChanges();

            return Ok(motorFromRepo);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMotor(int id)
        {
            
            var motor = _repository.GetMotorById(id);

            if(motor == null)
            {
                return NotFound();
            }

            _repository.DeleteMotor(motor);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}