using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Entities;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;

namespace SalonManager.Business.Features.Companies.Commands.Insert
{
    internal class InsertCompanyRequestHandler : IRequestHandler<InsertCompanyRequest, Result<InsertCompanyResponse>>
    {
        private readonly ICompanyCommandRepository _commandRepository;
        private readonly IValidator<InsertCompanyRequest> _validator;
        public InsertCompanyRequestHandler(ICompanyCommandRepository commandRepository, IValidator<InsertCompanyRequest> validator)
        {
            _commandRepository = commandRepository;
            _validator = validator;
        }
        public async Task<Result<InsertCompanyResponse>> Handle(InsertCompanyRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var company = new Company
                (
                    Guid.NewGuid(),
                    request.UserCreatorId,
                    request.Name,
                    request.CNPJ
                );

            var result = await _commandRepository.InsertAsync(company);

            if (result == null)
                return Result.Fail<InsertCompanyResponse>($"{nameof(BadRequestException)}|Nao foi possivel inserir a empresa");

            InsertCompanyResponse insertCompanyResponse = result;
            return Result.Ok(insertCompanyResponse);
        }
    }
}
