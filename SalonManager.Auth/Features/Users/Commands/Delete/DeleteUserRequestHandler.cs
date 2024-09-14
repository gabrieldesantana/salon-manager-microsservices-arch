using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Auth.Core.Interfaces.Repositories;
using SalonManager.Auth.CrossCutting.Exceptions;

namespace SalonManager.Auth.Features.Users.Commands.Delete
{
    internal class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, Result<DeleteUserResponse>>
    {
        private readonly IUserCommandRepository _commandRepository;
        private readonly IValidator<DeleteUserRequest> _validator;
        public DeleteUserRequestHandler(IUserCommandRepository commandRepository, IValidator<DeleteUserRequest> validator)
            => (_commandRepository, _validator) = (commandRepository, validator);

        public async Task<Result<DeleteUserResponse>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            bool status = await _commandRepository.DeleteAsync(request.Id);

            if (status)
                return Result.Fail<DeleteUserResponse>($"{nameof(BadRequestException)}|Nao foi possivel excluir o usuario de ID: {request.Id}");

            return Result.Ok(new DeleteUserResponse(request.Id, status));
        }
    }
}
