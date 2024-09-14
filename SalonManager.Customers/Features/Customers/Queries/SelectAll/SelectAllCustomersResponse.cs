using SalonManager.Customers.Core.Entities;
using SalonManager.Customers.CrossCutting.Models;
using SalonManager.Customers.Features.Customers.Queries.Select;

namespace SalonManager.Customers.Features.Customers.Queries.SelectAll
{
    public class SelectAllCustomersResponse
    {
        private const bool INCLUDEOBJECTS = false;

        public static PagedResult<SelectCustomerResponse> FromCustomersToPagedResult(List<Customer> customers, int pageNumber, int pageSize, int totalRecords)
        {
            var customersResponse = customers
                .Select(x => SelectCustomerResponse.FromCustomer(x, INCLUDEOBJECTS))
                .ToList();

            return new PagedResult<SelectCustomerResponse>(customersResponse, pageNumber, pageSize, totalRecords);
        }
    }
}
