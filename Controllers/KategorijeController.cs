using System.Collections.Generic;
using AutoPeda.Data;
using AutoPeda.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPeda.Controllers
{
    [Route("api/kategorije")]
    [ApiController]
    public class KategorijeController : ControllerBase
    {

        private readonly IAutoPedaRepo _repository;

        public KategorijeController(IAutoPedaRepo repository)
       {
           _repository = repository;
       }

        [HttpGet]
        public ActionResult<IEnumerable<KategorijaProizvoda>> GetAllKategorije()
        {
            return Ok(_repository.GetAllKategorije());
        }
    }
}