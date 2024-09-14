using Microsoft.AspNetCore.Mvc;

namespace SalonManager.Appointments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly ILogger<AppointmentsController> _logger;

        public AppointmentsController(ILogger<AppointmentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{tenantId}/{id}")]
        public async Task<IActionResult> Select(
            [FromRoute] int tenantId,
            [FromRoute] int id,
            CancellationToken cancellationToken)
            => Ok($"AppointmentsController : {tenantId},{id}");
    }
}
