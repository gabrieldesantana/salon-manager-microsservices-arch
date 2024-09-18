using FluentResults;
using FluentValidation;
using MediatR;
using SalonManager.Business.Core.Interfaces.Repositories;
using SalonManager.Business.CrossCutting.Exceptions;

namespace SalonManager.Business.Features.Companies.Commands.Delete
{
    internal class DeleteCompanyRequestHandler : IRequestHandler<DeleteCompanyRequest, Result<DeleteCompanyResponse>>
    {
        private readonly ICompanyCommandRepository _commandRepository;
        private readonly IValidator<DeleteCompanyRequest> _validator;
        public DeleteCompanyRequestHandler(ICompanyCommandRepository commandRepository, IValidator<DeleteCompanyRequest> validator)
        {
            _commandRepository = commandRepository;
            _validator = validator;
        }
        public async Task<Result<DeleteCompanyResponse>> Handle(DeleteCompanyRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var status = await _commandRepository.DeleteAsync(request.Id, request.TenantId);
            if (!status)
                return Result.Fail<DeleteCompanyResponse>($"{nameof(BadRequestException)}|Nao foi possivel excluir a empresa de ID: {request.Id}");

            return Result.Ok(new DeleteCompanyResponse(request.Id, status));
        }
    }
}
