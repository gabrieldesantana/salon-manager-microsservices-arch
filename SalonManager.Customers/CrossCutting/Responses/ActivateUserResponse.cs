namespace SalonManager.Customers.CrossCutting.Responses
{
    public class ActivateUserResponse
    {
        public ActivateUserResponse(Guid id, string login)
        {
            Id = id;
            Login = login;
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
    }
}
