using FluentResults;
using MediatR;

namespace SalonManager.Business.Features.Companies.Commands.Insert
{
    public class InsertCompanyRequest : IRequest<Result<InsertCompanyResponse>>
    {
        public InsertCompanyRequest(Guid userCreatorId, string? name, string? cNPJ)
        {
            UserCreatorId = userCreatorId;
            Name = name;
            CNPJ = cNPJ;
        }

        public Guid UserCreatorId { get; private set; }
        public string? Name { get; private set; }
        public string? CNPJ { get; private set; }
    }
}
