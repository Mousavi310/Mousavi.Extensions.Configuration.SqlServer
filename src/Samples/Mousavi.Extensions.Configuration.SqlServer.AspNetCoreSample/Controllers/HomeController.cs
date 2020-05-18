using AspNetCoreSample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCoreSample.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IOptions<JobOptions> _options;

        public HomeController(IOptionsSnapshot<JobOptions> options)
        {
            _options = options;
        }

        [Route("api")]
        public IActionResult Index()
        {
            return Ok(_options.Value.Interval);
        }
    }
}
