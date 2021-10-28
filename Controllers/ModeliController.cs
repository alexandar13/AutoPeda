using System;
using System.Collections.Generic;
using AutoMapper;
using AutoPeda.Data;
using AutoPeda.Dtos;
using AutoPeda.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace AutoPeda.Controllers
{
    [Route("api/modeli")]
    [ApiController]
    public class ModeliController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAutoPedaRepo _repository;

       public ModeliController(IAutoPedaRepo repository, IMapper mapper)
       {
           _mapper = mapper;
           _repository = repository;
       }

       [HttpGet]
       public ActionResult<IEnumerable<ModelReadDto>> GetAllModeli()
       {
            var sviModeli = _repository.GetAllModel();

            return Ok(_mapper.Map<IEnumerable<ModelReadDto>>(sviModeli));     
       }

        [HttpGet("{id}", Name="GetModelById")]
        [Route("ById/{id}")]
        public ActionResult<ModelReadDto> GetModelById(int id)
        {
            var model = _repository.GetModelById(id);

            return Ok(_mapper.Map<ModelReadDto>(model));     
        }

       [HttpPost]
       public ActionResult<ModelReadDto> CreateModel(ModelCreateDto ModelCreateDto)
       {
           var model = _mapper.Map<Model>(ModelCreateDto);

           _repository.CreateModel(model);
           _repository.SaveChanges();

            var ModelReadDto = _mapper.Map<ModelReadDto>(model);

            return Ok();

       }

       [HttpPut("{id}")]
       public ActionResult<Model> UpdateModel(int id, ModelUpdateDto modelUpdateDto)
       {
            var modelFromRepo = _repository.GetModelById(id);

            if(modelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(modelUpdateDto, modelFromRepo);

            _repository.SaveChanges();

            return NoContent();

       }

        [HttpPatch("{id}")]
        public ActionResult PartialModelUpdate(int id, JsonPatchDocument<ModelUpdateDto> patchDocument)
        {
            var modelFromRepo = _repository.GetModelById(id);
            if(modelFromRepo == null)
            {
                return NotFound();
            }

            var modelToPatch = _mapper.Map<ModelUpdateDto>(modelFromRepo);
            patchDocument.ApplyTo(modelToPatch, ModelState);

            if(!TryValidateModel(modelToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(modelToPatch, modelFromRepo);

            _repository.UpdateModel(modelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteModel(int id)
        {
            
            var model = _repository.GetModelById(id);

            if(model == null)
            {
                return NotFound();
            }

            _repository.DeleteModel(model);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpGet("{marka}")]
        [Route("ZaMarku/{marka}")]
        public ActionResult<IEnumerable<ModelReadDto>> getModelForMarka(string marka)
        {
            var modeli = _repository.getModelForMarka(marka);

            return Ok(_mapper.Map<IEnumerable<ModelReadDto>>(modeli)); 
        }

        [HttpGet("naziv")]
        [Route("PoNazivu/{naziv}/{marka}")]
        public ActionResult<IEnumerable<ModelReadDto>> getModelByName(string naziv, string marka)
        {
            var modeli = _repository.getModelByName(naziv, marka);

            return Ok(_mapper.Map<IEnumerable<ModelReadDto>>(modeli));
        }
    }
}