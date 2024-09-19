namespace SalonManager.Business.CrossCutting.Requests
{
    public class ActivateUserRequest
    {
        public ActivateUserRequest(Guid id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
