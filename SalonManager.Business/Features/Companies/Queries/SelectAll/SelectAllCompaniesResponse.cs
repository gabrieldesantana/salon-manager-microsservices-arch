using SalonManager.Business.Core.Entities;
using SalonManager.Business.CrossCutting.Models;
using SalonManager.Business.Features.Companies.Queries.Select;

namespace SalonManager.Business.Features.Companies.Queries.SelectAll
{
    public class SelectAllCompaniesResponse
    {
        private const bool INCLUDEOBJECTS = false;

        public static PagedResult<SelectCompanyResponse> FromCustomersToPagedResult(List<Company> companies, int pageNumber, int pageSize)
        {
            var companiesResponse = companies
                .Select(x => SelectCompanyResponse.FromCompany(x, INCLUDEOBJECTS))
                .ToList();

            return new PagedResult<SelectCompanyResponse>(companiesResponse, pageNumber, pageSize, companies.Count);
        }
    }
}
