using SalonManager.Business.Core.Entities;
using SalonManager.Business.CrossCutting.Models;
using SalonManager.Business.Features.SalonServices.Queries.Select;

namespace SalonManager.Business.Features.SalonServices.Queries.SelectAll
{
    public class SelectAllSalonServicesResponse
    {
        public static PagedResult<SelectSalonServiceResponse> FromSalonServicesToPagedResult(List<SalonService> salonServices, int pageNumber, int pageSize, int totalRecords)
        {
            var salonServicesResponse = salonServices
                .Select(x => SelectSalonServiceResponse.FromSalonService(x))
                .ToList();

            return new PagedResult<SelectSalonServiceResponse>(salonServicesResponse, pageNumber, pageSize, totalRecords);
        }
    }
}
