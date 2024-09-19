using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalonManager.Business.CrossCutting.Models;
using SalonManager.Business.Features.SalonServices.Commands.Delete;
using SalonManager.Business.Features.SalonServices.Commands.Insert;
using SalonManager.Business.Features.SalonServices.Commands.Update;
using SalonManager.Business.Features.SalonServices.Queries.Select;
using SalonManager.Business.Features.SalonServices.Queries.SelectAll;

namespace SalonManager.Business.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalonServicesController : MainController
    {
        public SalonServicesController(IMediator mediator)
                    : base(mediator)
        {
        }

        [Authorize(Roles = "Owner,Employee,Admin")]
        [HttpGet("{tenantId}/{id}")]
        public async Task<ActionResult<SelectSalonServiceResponse>> Select(
            [FromRoute] Guid tenantId,
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
            => await SendRequest(new SelectSalonServiceRequest(id, tenantId), cancellationToken);

        [Authorize(Roles = "Owner,Employee,Admin")]
        [HttpGet("{tenantId}")]
        public async Task<ActionResult<PagedResult<SelectSalonServiceResponse>>> SelectAll(
            [FromRoute] Guid tenantId,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            CancellationToken cancellationToken)
            => await SendRequest(new SelectAllSalonServicesRequest(tenantId, pageNumber, pageSize), cancellationToken);

        [Authorize(Roles = "Owner,Employee,Admin")]
        [HttpPost("")]
        public async Task<ActionResult<InsertSalonServiceResponse>> Insert(
            [FromBody] InsertSalonServiceRequest request, CancellationToken cancellationToken)
            => await SendRequest(request, cancellationToken);

        [Authorize(Roles = "Owner,Employee,Admin")]
        [HttpPut("")]
        public async Task<ActionResult<UpdateSalonServiceResponse>> Update(
            [FromBody] UpdateSalonServiceRequest request, CancellationToken cancellationToken)
            => await SendRequest(request, cancellationToken);

        [Authorize(Roles = "Owner,Admin")]
        [HttpDelete("{tenantId}/{id}")]
        public async Task<ActionResult<DeleteSalonServiceResponse>> Delete(
            [FromRoute] Guid tenantId, [FromRoute] Guid id, CancellationToken cancellationToken)
            => await SendRequest(new DeleteSalonServiceRequest(id, tenantId), cancellationToken);
    }
}
