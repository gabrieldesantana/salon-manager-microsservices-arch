using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalonManager.Auth.CrossCutting.Models;
using SalonManager.Auth.Features.Users.Commands.Delete;
using SalonManager.Auth.Features.Users.Commands.Insert;
using SalonManager.Auth.Features.Users.Commands.Update;
using SalonManager.Auth.Features.Users.Queries.Select;
using SalonManager.Auth.Features.Users.Queries.SelectAll;

namespace SalonManager.Auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : MainController
    {
        public UsersController(IMediator mediator)
                    : base(mediator)
        {
        }

        ////[Authorize(Roles = "Admin")]/
        [HttpGet("{id}")]
        public async Task<ActionResult<SelectUserResponse>> Select(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
            => await SendRequest(new SelectUserRequest(id), cancellationToken);

        ////[Authorize(Roles = "Admin")]
        [HttpGet("")]
        public async Task<ActionResult<PagedResult<SelectUserResponse>>> SelectAll(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            CancellationToken cancellationToken)
            => await SendRequest(new SelectAllUsersRequest(pageNumber, pageSize), cancellationToken);

        ////[Authorize(Roles = "Admin")]
        [HttpPost("")]
        public async Task<ActionResult<InsertUserResponse>> Insert(
            [FromBody] InsertUserRequest request, CancellationToken cancellationToken)
            => await SendRequest(request, cancellationToken);

        [Authorize(Roles = "Admin")]
        [HttpPut("")]
        public async Task<ActionResult<UpdateUserResponse>> Update(
            [FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
            => await SendRequest(request, cancellationToken);

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteUserResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
            => await SendRequest(new DeleteUserRequest(id), cancellationToken);
    }
}
