using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalonManager.Customers.CrossCutting.Exceptions;

namespace SalonManager.Customers.Controllers
{
    public class MainController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<ActionResult<T>> SendRequest<T>(IRequest<Result<T>> request, CancellationToken cancellationToken, int statusCode = 200)
        {
            var response = await _mediator.Send(request, cancellationToken).ConfigureAwait(false);
            return (response.IsSuccess)
            ? statusCode switch
            {
                200 => StatusCode(statusCode, response.Value),
                201 => Created(),
                204 => NoContent(),
                _ => StatusCode(statusCode, response.Value)
            }
           : HandleError(response.Errors);
        }

        protected ActionResult HandleError(List<IError> errors)
        {
            var firstError = errors.FirstOrDefault();
            var typeOfException = firstError!.Message.Split('|').First();
            var message = firstError!.Message.Split('|').Last().ToString();

            return typeOfException switch
            {
                nameof(InvalidRequestDataException) => BadRequest(message ?? ""),
                nameof(BadRequestException) => BadRequest(message ?? ""),
                nameof(NotFoundException) => NotFound(message ?? ""),
                nameof(UnauthorizedException) => Unauthorized(message ?? ""),
                _ => Problem(statusCode: 500, detail: message ?? "")
            };
        }

    }
}
