using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                using (var client = new HttpClient ())
                {
                    client.BaseAddress = new Uri("https://localhost:44331/api/");
                    
                    //HttpStatusCode a = HttpStatusCode.OK;
                    
                    var result = await client.GetStringAsync("products");

                    _logger.LogInformation("Response: {0}", result);

                    Product[] models = JsonSerializer.Deserialize<Product[]>(result);
                    
                    ViewData["Models"] = models;

                    return ViewResult();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
