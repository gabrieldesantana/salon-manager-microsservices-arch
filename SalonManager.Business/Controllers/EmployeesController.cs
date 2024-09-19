using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalonManager.Business.CrossCutting.Models;
using SalonManager.Business.Features.Employees.Commands.Delete;
using SalonManager.Business.Features.Employees.Commands.Insert;
using SalonManager.Business.Features.Employees.Commands.Update;
using SalonManager.Business.Features.Employees.Queries.Select;
using SalonManager.Business.Features.Employees.Queries.SelectAll;

namespace SalonManager.Business.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : MainController
    {
        public EmployeesController(IMediator mediator)
            : base(mediator)
        {
        }

        [Authorize(Roles = "Owner,Admin,Employee")]
        [HttpGet("{tenantId}/{id}")]
        public async Task<ActionResult<SelectEmployeeResponse>> Select(
            [FromRoute] Guid tenantId,
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
            => await SendRequest(new SelectEmployeeRequest(id, tenantId), cancellationToken);

        [Authorize(Roles = "Owner,Admin")]
        [HttpGet("{tenantId}")]
        public async Task<ActionResult<PagedResult<SelectEmployeeResponse>>> SelectAll(
            [FromRoute] Guid tenantId,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            CancellationToken cancellationToken)
            => await SendRequest(new SelectAllEmployeesRequest(tenantId, pageNumber, pageSize), cancellationToken);

        [Authorize(Roles = "Owner,Admin")]
        [HttpPost("")]
        public async Task<ActionResult<InsertEmployeeResponse>> Insert(
            [FromBody] InsertEmployeeRequest request, CancellationToken cancellationToken)
            => await SendRequest(request, cancellationToken);

        [Authorize(Roles = "Owner,Admin")]
        [HttpPut("")]
        public async Task<ActionResult<UpdateEmployeeResponse>> Update(
            [FromBody] UpdateEmployeeRequest request, CancellationToken cancellationToken)
            => await SendRequest(request, cancellationToken);

        [Authorize(Roles = "Owner,Admin")]
        [HttpDelete("{tenantId}/{id}")]
        public async Task<ActionResult<DeleteEmployeeResponse>> Delete(
            [FromRoute] Guid tenantId, [FromRoute] Guid id, CancellationToken cancellationToken)
            => await SendRequest(new DeleteEmployeeRequest(id, tenantId), cancellationToken);
    }
}
