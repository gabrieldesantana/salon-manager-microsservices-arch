using FluentResults;
using FluentValidation;
using MediatR;
using Refit;
using SalonManager.Customers.Core.Entities;
using SalonManager.Customers.Core.Interfaces.Repositories;
using SalonManager.Customers.Core.Interfaces.Services;
using SalonManager.Customers.CrossCutting.Dtos;
using SalonManager.Customers.CrossCutting.Enums;
using SalonManager.Customers.CrossCutting.Exceptions;
using SalonManager.Customers.CrossCutting.Requests;
using SalonManager.Customers.Infrastructure.Refit;

namespace SalonManager.Customers.Features.Customers.Commands.Insert
{
    internal class InsertCustomerRequestHandler : IRequestHandler<InsertCustomerRequest, Result<InsertCustomerResponse>>
    {
        private readonly ICustomerCommandRepository _commandRepository;
        private readonly IUserServiceRefit _userServiceRefit;
        private readonly IAuthService _authService;
        private readonly IValidator<InsertCustomerRequest> _validator;

        public InsertCustomerRequestHandler(
            ICustomerCommandRepository commandRepository,
            IUserServiceRefit userServiceRefit,
            IAuthService authService,
            IValidator<InsertCustomerRequest> validator)
            => (_commandRepository, _userServiceRefit, _authService, _validator) = (commandRepository, userServiceRefit, authService, validator);
        public async Task<Result<InsertCustomerResponse>> Handle(InsertCustomerRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var userLogin = FormartToLoginName(request.FullName);
            var userPassword = GenerateDefaultPassword(request.FullName, request.Cpf);

            var passwordHash = _authService.ComputeSha256Hash(userPassword);

            UserDto newUserToCustomer = new(
                request.FullName,
                userLogin,
                string.IsNullOrWhiteSpace(request.Email) ? "vazio" : request.Email,
                passwordHash,
                EUserRole.Customer
                );

            var requestUser = new InsertUserRequest(newUserToCustomer.FullName, newUserToCustomer.Login, newUserToCustomer.Email, newUserToCustomer.Password, (int)newUserToCustomer.Role);
            var resultCreateUser = await _userServiceRefit.InsertUserAsync(requestUser);

            if (!resultCreateUser.IsSuccessStatusCode || resultCreateUser.Content == null)
                return Result.Fail<InsertCustomerResponse>($"{nameof(ApiException)}|Nao foi possivel inserir o usuario vinculado ao cliente");

            Customer customer = new(
                request.TenantId,
                request.UserCreatorId,
                resultCreateUser.Content.Id,
                request.Cpf,
                request.FullName,
                request.Nickname,
                request.Gender,
                request.BirthDate,
                request.PhoneNumber
                );

            var resultCreateCustomer = await _commandRepository.InsertAsync(customer);

            if (resultCreateCustomer == null)
                return Result.Fail<InsertCustomerResponse>($"{nameof(BadRequestException)}|Nao foi possivel inserir o cliente");

            InsertCustomerResponse insertCustomerResponse = resultCreateCustomer;
            return Result.Ok(insertCustomerResponse);
        }
        private static string FormartToLoginName(string fullName)
        {
            var prepositions = new List<string> { "de", "da", "do", "das", "dos" };

            var nameParts = fullName.Split(' ')
                                    .Where(p => !prepositions.Contains(p.ToLower()))
                                    .Select(p => p.ToLower())
                                    .ToList();

            string username = (nameParts.Count > 2)
                ? $"{nameParts[0]}.{nameParts.Last()}"
                : string.Join(".", nameParts);

            return username;
        }
        private static string GenerateDefaultPassword(string fullName, string cpf)
        {
            var cpfPart = cpf.Split('.').First();
            var namePart = fullName.Split(' ').First();
            var especialCharacter = (cpf[0] % 2 == 0) ? ";" : "!";

            return namePart + cpfPart + especialCharacter;
        }
    }
}
