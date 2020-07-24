using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public ActionResult<IEnumerable<object>> Get()
        {
            
            var result = _repository.Get();

            _logger.LogInformation("Variable {0}", _settings.Variable);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public object GetById(int id) 
        {
            var result = _repository.GetById(id);

            if (result == null)
            {
                return NotFound(new {Message = "No se encuentra el elemento" });
            }   
            return result;
        }

        [HttpPost]
        public IActionResult Create([FromBody] string name)
        {
            _repository.Save(name);

            var items = _repository.Get();
            dynamic value = items.Last();
            return CreatedAtAction(nameof(GetById), new { Id= value.Id }, value);
        }

        [HttpPut("id")]
        public IActionResult Put(int id)
        {
            return new ObjectResult(new object()) { StatusCode = (int)HttpStatusCode.NotImplemented};
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            return new ObjectResult(new object()) { StatusCode = (int)HttpStatusCode.NotImplemented };
        }

    }
}
