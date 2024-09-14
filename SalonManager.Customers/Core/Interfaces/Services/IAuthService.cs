namespace SalonManager.Customers.Core.Interfaces.Services
{
    public interface IAuthService
    {
        string ComputeSha256Hash(string password);
    }
}
