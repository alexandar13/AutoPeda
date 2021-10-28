using System.Collections.Generic;
using AutoMapper;
using AutoPeda.Data;
using AutoPeda.Dtos;
using AutoPeda.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPeda.Controllers
{
    [Route("api/potkategorije")]
    [ApiController]
    public class PotkategorijeController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IAutoPedaRepo _repository;

        public PotkategorijeController(IAutoPedaRepo repository, IMapper mapper)
       {
           _mapper = mapper;
           _repository = repository;
       }

        [HttpGet]
        public ActionResult<IEnumerable<PotkategorijaDto>> GetAllPotkategorije()
        {
            var svePotkategorije = _repository.GetAllPotkategorije();
            return Ok(_mapper.Map<IEnumerable<PotkategorijaDto>>(svePotkategorije));
        }
    }
}