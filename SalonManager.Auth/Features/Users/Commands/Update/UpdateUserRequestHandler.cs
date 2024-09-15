using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Auth.Core.Interfaces.Repositories;
using SalonManager.Auth.CrossCutting.Exceptions;

namespace SalonManager.Auth.Features.Users.Commands.Update
{
    internal class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, Result<UpdateUserResponse>>
    {
        private readonly IUserCommandRepository _commandRepository;
        private readonly IUserQueryRepository _queryRepository;
        private readonly IValidator<UpdateUserRequest> _validator;
        public UpdateUserRequestHandler(IUserCommandRepository commandRepository, IUserQueryRepository queryRepository, IValidator<UpdateUserRequest> validator)
            => (_commandRepository, _queryRepository, _validator) = (commandRepository, queryRepository, validator);

        public async Task<Result<UpdateUserResponse>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var user = await _queryRepository.GetByIdAsync(request.Id);

            if (user == null)
                return Result.Fail<UpdateUserResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o usuario de ID: {request.Id}");

            user.Update(request.FullName!, request.Login!, request.Email!);

            var result = await _commandRepository.UpdateAsync(user, request.Id);
            if (result == null)
                return Result.Fail<UpdateUserResponse>($"{nameof(BadRequestException)}|Houve um erro ao persistir a alteração no banco de dados");

            UpdateUserResponse updateUserResponse = user;
            return Result.Ok(updateUserResponse);
        }
    }
}
