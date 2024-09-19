using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Auth.Core.Entities;
using SalonManager.Auth.Core.Interfaces.Repositories;
using SalonManager.Auth.Core.Interfaces.Services;
using SalonManager.Auth.CrossCutting.Exceptions;

namespace SalonManager.Auth.Features.Users.Commands.Insert
{
    internal class InsertUserRequestHandler : IRequestHandler<InsertUserRequest, Result<InsertUserResponse>>
    {
        private readonly IUserCommandRepository _commandRepository;
        private readonly IAuthService _authService;
        private readonly IValidator<InsertUserRequest> _validator;

        public InsertUserRequestHandler(IValidator<InsertUserRequest> validator, IAuthService authService, IUserCommandRepository commandRepository)
            => (_commandRepository, _authService, _validator) = (commandRepository, authService, validator);
        public async Task<Result<InsertUserResponse>> Handle(InsertUserRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var passwordHash = request.Password;

            if (request.Password!.Length < 50)
                passwordHash = _authService.ComputeSha256Hash(request.Password);

            User user = new(
               request.FullName,
               request.Login,
               request.Email,
               passwordHash,
               request.Role
               );

            var result = await _commandRepository.InsertAsync(user);

            if (result == null)
                return Result.Fail<InsertUserResponse>($"{nameof(BadRequestException)}|Nao foi possivel inserir o usuario");

            ///ATIVAR O USUARIO

            InsertUserResponse insertUserResponse = result;
            return Result.Ok(insertUserResponse);
        }
    }
}
