namespace SalonManager.Auth.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordResponse
    {
        public ChangePasswordResponse(Guid id, string newPassword)
        {
            Id = id;
            NewPassword = newPassword;
        }

        public Guid Id { get; private set; }
        public string NewPassword { get; private set; }
    }
}
