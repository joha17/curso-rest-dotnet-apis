using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Repositories;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {


        private readonly ILogger<ProductsController> _logger;
        private readonly ApplicationSettings _settings;
        private readonly ProductRepository _repository;

        public ProductsController(ILogger<ProductsController> logger, ApplicationSettings settings, ProductRepository repository)
        {
            _logger = logger;
            _settings = settings;
            _repository = repository;
        }

        [HttpGet]
        [Produces(typeof(ProductViewModel))]
        public ActionResult<IEnumerable<object>> Get()
        {
            
            var result = _repository.Get();

            _logger.LogInformation("Variable {0}", _settings.Variable);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public object GetById(int id) 
        {
            var result = _repository.Get(id);

            if (result == null)
            {
                return NotFound(new {Message = "No se encuentra el elemento" });
            }   
            return result;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Parametros invalidos");
            }
            request.Id =  _repository.Save(request);

            return CreatedAtAction(nameof(GetById), new { Id= request.Id }, request);
        }

        [HttpPut("id")]
        public IActionResult Put([FromBody] ProductViewModel request, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Parametros invalidos");
            }
            var result = _repository.Update(id, request);
            return result ? (IActionResult)Ok() : NotFound();
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            return result ? (IActionResult)Ok() : NotFound();
        }

    }
}
