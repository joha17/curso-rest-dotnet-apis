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
using Newtonsoft.Json;
using WebApplicationCORS;

namespace WebApplicatioCORS.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [ViewData]
        public List<Movies> Moviees { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                List<Movies> reservationList = new List<Movies>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:44326/movies/"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        reservationList = JsonConvert.DeserializeObject<List<Movies>>(apiResponse);
                    }
                }
                Moviees = reservationList;
                return Page();
            }
            catch (Exception ex )
            {

                throw ex;
            }
            
        }
    }
}
