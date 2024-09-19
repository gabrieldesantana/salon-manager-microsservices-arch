using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalonManager.Auth.Features.Auth.Commands.ChangePassword;
using SalonManager.Auth.Features.Auth.Commands.Login;

namespace SalonManager.Auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : MainController
    {

        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginUserResponse>> Login(
        [FromBody] LoginUserRequest request, CancellationToken cancellationToken)
        => await SendRequest(request, cancellationToken);

        [Authorize(Roles = "Owner,Employee,Customer,Admin")]
        [HttpPut("changePassword")]
        public async Task<ActionResult<ChangePasswordResponse>> ChangePassword(
        [FromBody] ChangePasswordRequest request, CancellationToken cancellationToken)
        => await SendRequest(request, cancellationToken);
    }
}
