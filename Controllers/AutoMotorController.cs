using System.Collections.Generic;
using AutoMapper;
using AutoPeda.Data;
using AutoPeda.Dtos;
using AutoPeda.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace AutoPeda.Controllers
{
    [Route("api/automotor")]
    [ApiController]
    public class AutoMotorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAutoPedaRepo _repository;

       public AutoMotorController(IAutoPedaRepo repository, IMapper mapper)
       {
           _mapper = mapper;
           _repository = repository;
       }

       [HttpGet]
       public ActionResult<IEnumerable<AutoMotor>> GetAllAutoMotor()
       {
            var sviAutoMotor = _repository.GetAllAutoMotor();

            return Ok(sviAutoMotor);     
       }

        [HttpGet("{id}", Name="GetAutoMotorById")]
        public ActionResult<AutoMotorReadDto> GetAutoMotorByAutoId(int id)
        {
                var autoMotor = _repository.GetAutoMotorByAutoId(id);

                return Ok(_mapper.Map<AutoMotorReadDto>(autoMotor));     
        }

       [HttpPost]
       public ActionResult<AutoMotor> CreateAutoMotor(AutoMotor autoMotor)
       {

           _repository.CreateAutoMotor(autoMotor);
           _repository.SaveChanges();

            return Ok();

       }

        [HttpDelete("{id}")]
        public ActionResult DeleteAutoMotor(int AutoId, int MotorId)
        {
            
            var autoMotor = _repository.GetAutoMotorById(AutoId, MotorId);

            if(autoMotor == null)
            {
                return NotFound();
            }

            _repository.DeleteAutoMotor(autoMotor);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}