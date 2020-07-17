using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] Products = new[]
        {
            "Jeans", "Pants", "Boxers", "Socks", "Shoes"
        };

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            int i = 0;
            var result = Products.Select(model => new {
                Name = model,
                Id = i++
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public object GetById(int id)
        {
            int i = 0;
            var result = Products.Select(model => new {
                Name = model,
                Id = i++
            }).ToList();

            if (result.ElementAtOrDefault(id) == null)
            {
                return NotFound(new { Message = "No se encuentra el producto"});
            }

            return result[id];
        }
    }
}
