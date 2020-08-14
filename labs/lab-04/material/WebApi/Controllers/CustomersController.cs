using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Repositories;
using WebApi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;
        private readonly ApplicationSettings _settings;
        private readonly CustomerRepository _repository;

        public CustomersController(ILogger<ProductsController> logger, ApplicationSettings settings, CustomerRepository repository)
        {
            _logger = logger;
            _settings = settings;
            _repository = repository;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        [Produces(typeof(CustomerViewModel))]
        public ActionResult<IEnumerable<object>> Get()
        {
            var result = _repository.Get();

            _logger.LogInformation("Variable {0}", _settings.Variable);

            return Ok(result);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public object GetById(int id)
        {
            var result = _repository.Get(id);

            if (result == null)
            {
                return NotFound(new { Message = "No se encuentra el elemento" });
            }
            return result;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Create([FromBody] CustomerViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Parametros invalidos");
            }
            request.CustomerId = _repository.Save(request);

            return CreatedAtAction(nameof(GetById), new { Id = request.CustomerId }, request);
        }

        [HttpPut("id")]
        public IActionResult Put([FromBody] CustomerViewModel request, int id)
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
