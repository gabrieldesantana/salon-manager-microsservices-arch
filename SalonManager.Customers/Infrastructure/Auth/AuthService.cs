using SalonManager.Customers.Core.Interfaces.Services;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SalonManager.Customers.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        public string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
