using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Auth.Core.Interfaces.Repositories;
using SalonManager.Auth.CrossCutting.Exceptions;

namespace SalonManager.Auth.Features.Users.Commands.ActivateUser
{
    public class ActivateUserRequestHandler : IRequestHandler<ActivateUserRequest, Result<ActivateUserResponse>>
    {
        private readonly IUserCommandRepository _commandRepository;
        private readonly IUserQueryRepository _queryRepository;
        private readonly IValidator<ActivateUserRequest> _validator;
        public ActivateUserRequestHandler(IUserCommandRepository commandRepository, IUserQueryRepository queryRepository, IValidator<ActivateUserRequest> validator)
            => (_commandRepository, _queryRepository, _validator) = (commandRepository, queryRepository, validator);

        public async Task<Result<ActivateUserResponse>> Handle(ActivateUserRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var user = await _queryRepository.GetByIdAsync(request.Id);

            if (user == null)
                return Result.Fail<ActivateUserResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o usuario de ID: {request.Id}");

            user.ActivateUser(request.FullName);

            var result = await _commandRepository.UpdateAsync(user, request.Id);
            if (result == null)
                return Result.Fail<ActivateUserResponse>($"{nameof(BadRequestException)}|Houve um erro ao persistir a alteração no banco de dados");

            ActivateUserResponse activateUserResponse = user;

            return Result.Ok(activateUserResponse);
        }
    }
}
