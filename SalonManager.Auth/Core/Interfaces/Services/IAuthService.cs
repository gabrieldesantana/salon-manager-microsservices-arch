namespace SalonManager.Auth.Core.Interfaces.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
        string ComputeSha256Hash(string password);
    }
}
