using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngine.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LookupController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ISearchService _search;

        public LookupController(ILogger<SearchController> logger, ISearchService searchService)
        {
            _logger = logger;
            _search = searchService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            string lookup = HttpContext.Request.Query["lookup"].ToString();

            if (string.IsNullOrEmpty(lookup))
            {
                return null;
            }

            return _search.Find(lookup).Select(e => e.Word).Take(15).ToHashSet();
        }
    }
}
