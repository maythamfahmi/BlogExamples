using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using SearchEngine.Model;

namespace SearchEngine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ISearchService _search;
        
        public SearchController(ILogger<SearchController> logger, ISearchService searchService)
        {
            _logger = logger;
            _search = searchService;
        }

        [HttpGet]
        public IEnumerable<SearchData> Get()
        {
            string search = HttpContext.Request.Query["search"].ToString();

            if (string.IsNullOrEmpty(search))
            {
                return null;
            }
            
            return _search.Find(search);
        }
    }
}
