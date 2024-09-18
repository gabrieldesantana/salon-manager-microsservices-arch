using SalonManager.Business.Core.Entities;
using SalonManager.Business.CrossCutting.Models;
using SalonManager.Business.Features.Employees.Queries.Select;

namespace SalonManager.Business.Features.Employees.Queries.SelectAll
{
    public class SelectAllEmployeesResponse
    {
        private const bool INCLUDEOBJECTS = false;

        public static PagedResult<SelectEmployeeResponse> FromEmployeesToPagedResult(List<Employee> employees, int pageNumber, int pageSize, int totalRecords)
        {
            var employeesResponse = employees
                .Select(x => SelectEmployeeResponse.FromEmployee(x, INCLUDEOBJECTS))
                .ToList();

            return new PagedResult<SelectEmployeeResponse>(employeesResponse, pageNumber, pageSize, totalRecords);
        }
    }
}
