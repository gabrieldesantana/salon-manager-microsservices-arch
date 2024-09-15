using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalonManager.Customers.CrossCutting.Models;
using SalonManager.Customers.Features.Customers.Commands.Delete;
using SalonManager.Customers.Features.Customers.Commands.IncreaseVisitedTimes;
using SalonManager.Customers.Features.Customers.Commands.Insert;
using SalonManager.Customers.Features.Customers.Commands.Update;
using SalonManager.Customers.Features.Customers.Queries.Select;
using SalonManager.Customers.Features.Customers.Queries.SelectAll;

namespace SalonManager.Customers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : MainController
    {
        public CustomersController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet("{tenantId}/{id}")]
        public async Task<ActionResult<SelectCustomerResponse>> Select(
            [FromRoute] Guid tenantId,
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
            => await SendRequest(new SelectCustomerRequest(id, tenantId), cancellationToken);

        [HttpGet("{tenantId}")]
        public async Task<ActionResult<PagedResult<SelectCustomerResponse>>> SelectAll(
            [FromRoute] Guid tenantId,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            CancellationToken cancellationToken)
            => await SendRequest(new SelectAllCustomersRequest(tenantId, pageNumber, pageSize), cancellationToken);

        [HttpPost("")]
        public async Task<ActionResult<InsertCustomerResponse>> Insert(
            [FromBody] InsertCustomerRequest request, CancellationToken cancellationToken)
            => await SendRequest(request, cancellationToken);

        [HttpPut("")]
        public async Task<ActionResult<UpdateCustomerResponse>> Update(
            [FromBody] UpdateCustomerRequest request, CancellationToken cancellationToken)
            => await SendRequest(request, cancellationToken);

        [HttpDelete("{tenantId}/{id}")]
        public async Task<ActionResult<DeleteCustomerResponse>> Delete(
            [FromRoute] Guid tenantId, [FromRoute] Guid id, CancellationToken cancellationToken)
            => await SendRequest(new DeleteCustomerRequest(id, tenantId), cancellationToken);

        [HttpPut("increase-visited-times")]
        public async Task<ActionResult<IncreaseVisitedTimesResponse>> UpdateStatus(
        [FromBody] IncreaseVisitedTimesRequest request, CancellationToken cancellationToken)
        => await SendRequest(request, cancellationToken);
    }
}
