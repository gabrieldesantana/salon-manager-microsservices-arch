using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalonManager.Business.CrossCutting.Models;
using SalonManager.Business.Features.Companies.Commands.Delete;
using SalonManager.Business.Features.Companies.Commands.Insert;
using SalonManager.Business.Features.Companies.Commands.Update;
using SalonManager.Business.Features.Companies.Queries.Select;
using SalonManager.Business.Features.Companies.Queries.SelectAll;

namespace SalonManager.Business.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : MainController
    {
        public CompaniesController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet("{tenantId}/{id}")]
        public async Task<ActionResult<SelectCompanyResponse>> Select(
            [FromRoute] Guid tenantId,
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
            => await SendRequest(new SelectCompanyRequest(tenantId, id), cancellationToken);

        [HttpGet("")]
        public async Task<ActionResult<PagedResult<SelectCompanyResponse>>> SelectAll(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            CancellationToken cancellationToken)
            => await SendRequest(new SelectAllCompaniesRequest(pageNumber, pageSize), cancellationToken);

        [HttpPost("")]
        public async Task<ActionResult<InsertCompanyResponse>> Insert(
            [FromBody] InsertCompanyRequest request, CancellationToken cancellationToken)
            => await SendRequest(request, cancellationToken);

        [HttpPut("")]
        public async Task<ActionResult<UpdateCompanyResponse>> Update(
            [FromBody] UpdateCompanyRequest request, CancellationToken cancellationToken)
            => await SendRequest(request, cancellationToken);

        [HttpDelete("{tenantId}/{id}")]
        public async Task<ActionResult<DeleteCompanyResponse>> Delete(
            [FromRoute] Guid tenantId, [FromRoute] Guid id, CancellationToken cancellationToken)
            => await SendRequest(new DeleteCompanyRequest(id, tenantId), cancellationToken);
    }
}
