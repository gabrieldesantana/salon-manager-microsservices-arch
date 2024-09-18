using Microsoft.AspNetCore.Mvc;

namespace SalonManager.Business.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalonServicesController : ControllerBase
    {
        private readonly ILogger<SalonServicesController> _logger;

        public SalonServicesController(ILogger<SalonServicesController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
