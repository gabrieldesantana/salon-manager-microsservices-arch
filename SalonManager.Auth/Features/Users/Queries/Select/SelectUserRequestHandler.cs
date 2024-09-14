using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Auth.Core.Interfaces.Repositories;
using SalonManager.Auth.CrossCutting.Exceptions;

namespace SalonManager.Auth.Features.Users.Queries.Select
{
    internal class SelectUserRequestHandler : IRequestHandler<SelectUserRequest, Result<SelectUserResponse>>
    {
        private readonly IUserQueryRepository _queryRepository;
        private readonly IValidator<SelectUserRequest> _validator;
        public SelectUserRequestHandler(IUserQueryRepository queryRepository, IValidator<SelectUserRequest> validator)
            => (_queryRepository, _validator) = (queryRepository, validator);

        public async Task<Result<SelectUserResponse>> Handle(SelectUserRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var user = await _queryRepository.GetByIdAsync(request.Id);

            if (user == null)
                return Result.Fail<SelectUserResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar o usuario de ID: {request.Id}");

            SelectUserResponse selectUserResponse = user;
            return Result.Ok(selectUserResponse);
        }
    }
}
