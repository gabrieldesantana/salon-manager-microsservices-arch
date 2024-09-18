using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;

namespace SalonManager.Business.Features.Companies.Commands.Update
{
    internal class UpdateCompanyRequestHandler : IRequestHandler<UpdateCompanyRequest, Result<UpdateCompanyResponse>>
    {
        private readonly IValidator<UpdateCompanyRequest> _validator;
        private readonly ICompanyCommandRepository _commandRepository;
        private readonly ICompanyQueryRepository _queryRepository;
        public UpdateCompanyRequestHandler(IValidator<UpdateCompanyRequest> validator, ICompanyCommandRepository commandRepository, ICompanyQueryRepository queryRepository)
        {
            _validator = validator;
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }
        public async Task<Result<UpdateCompanyResponse>> Handle(UpdateCompanyRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var company = await _queryRepository.GetByIdAsync(request.Id, request.TenantId);

            if (company == null)
                return Result.Fail<UpdateCompanyResponse>($"{nameof(NotFoundException)}|Nao foi possivel localizar a empresa de ID: {request.Id}");

            company.Update(request.Name, request.CNPJ);

            var result = await _commandRepository.UpdateAsync(company, request.Id);
            if (result == null)
                return Result.Fail<UpdateCompanyResponse>($"{nameof(BadRequestException)}|Houve um erro ao persistir a alteração no banco de dados");

            UpdateCompanyResponse updateCompanyResponse = company;
            return Result.Ok(updateCompanyResponse);
        }
    }
}
