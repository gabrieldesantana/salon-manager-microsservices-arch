namespace SalonManager.Auth.CrossCutting.Models
{
    public class PagedResult<T>
    {
        public PagedResult(List<T> records, int pageNumber, int pageSize, int totalRecords)
        {
            Records = records;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
        }

        public List<T> Records { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages - 1;

    }
}
