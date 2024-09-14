using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Auth.Core.Interfaces.Repositories;
using SalonManager.Auth.CrossCutting.Models;
using SalonManager.Auth.Features.Users.Queries.Select;

namespace SalonManager.Auth.Features.Users.Queries.SelectAll
{
    internal class SelectAllUsersRequestHandler : IRequestHandler<SelectAllUsersRequest, Result<PagedResult<SelectUserResponse>>>
    {
        private readonly IUserQueryRepository _queryRepository;
        private readonly IUserCommandRepository _commandRepository;
        private readonly IValidator<SelectAllUsersRequest> _validator;
        public SelectAllUsersRequestHandler(IUserQueryRepository queryRepository, IUserCommandRepository commandRepository, IValidator<SelectAllUsersRequest> validator)
            => (_queryRepository, _commandRepository, _validator) = (queryRepository, commandRepository, validator);

        public async Task<Result<PagedResult<SelectUserResponse>>> Handle(SelectAllUsersRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var users = await _queryRepository.GetAllAsync(request.PageNumber, request.PageSize);
            var totalUsers = await _commandRepository.CountAsync();

            return Result.Ok(SelectAllUsersResponse.FromUsersToPagedResult(users, request.PageNumber, request.PageSize, totalUsers));
        }
    }
}
