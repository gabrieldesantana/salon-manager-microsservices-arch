using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Auth.Core.Interfaces.Repositories;
using SalonManager.Auth.Core.Interfaces.Services;
using SalonManager.Auth.CrossCutting.Exceptions;

namespace SalonManager.Auth.Features.Auth.Commands.ChangePassword
{
    internal class ChangePasswordRequestHandler : IRequestHandler<ChangePasswordRequest, Result<ChangePasswordResponse>>
    {
        private readonly IUserCommandRepository _commandRepository;
        private readonly IUserQueryRepository _queryRepository;
        private readonly IAuthService _authService;
        private readonly IValidator<ChangePasswordRequest> _validator;
        public ChangePasswordRequestHandler(IUserCommandRepository commandRepository, IUserQueryRepository queryRepository, IAuthService authService, IValidator<ChangePasswordRequest> validator)
            => (_commandRepository, _queryRepository, _authService, _validator) = (commandRepository, queryRepository, authService, validator);

        public async Task<Result<ChangePasswordResponse>> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var oldPasswordHash = _authService.ComputeSha256Hash(request.OldPassword);

            var user = await _queryRepository.GetUserByIdAndPasswordAsync(request.Id, oldPasswordHash);

            if (user == null)
                return Result.Fail<ChangePasswordResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o usuario de ID: {request.Id}");

            var passwordHash = _authService.ComputeSha256Hash(request.NewPasswordTwo);

            user.ChangePassword(passwordHash);

            await _commandRepository.UpdateAsync(user, request.Id);

            return Result.Ok(new ChangePasswordResponse(user.Id, passwordHash));
        }
    }
}
