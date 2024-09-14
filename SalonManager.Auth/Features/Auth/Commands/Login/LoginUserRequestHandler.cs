using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Auth.Core.Interfaces.Repositories;
using SalonManager.Auth.Core.Interfaces.Services;
using SalonManager.Auth.CrossCutting.Exceptions;

namespace SalonManager.Auth.Features.Auth.Commands.Login
{
    internal class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, Result<LoginUserResponse>>
    {
        private readonly IAuthService _authService;
        private readonly IUserCommandRepository _commandRepository;
        private readonly IUserQueryRepository _queryRepository;
        private readonly IValidator<LoginUserRequest> _validator;
        public LoginUserRequestHandler(IAuthService authService, IUserCommandRepository commandRepository, IUserQueryRepository queryRepository, IValidator<LoginUserRequest> validator)
            => (_authService, _commandRepository, _queryRepository, _validator) = (authService, commandRepository, queryRepository, validator);
        public async Task<Result<LoginUserResponse>> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _queryRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
                return Result.Fail<LoginUserResponse>($"{nameof(UnauthorizedException)}|Credenciais de acesso inválidas");

            var token = _authService.GenerateJwtToken(user.Email, user.Role.ToString());

            return Result.Ok(new LoginUserResponse(user.Email, token));
        }
    }
}
