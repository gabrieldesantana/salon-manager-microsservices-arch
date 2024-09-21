using Npgsql;
using System.Data;

namespace SalonManager.Customers.Infrastructure.Context
{
    public sealed class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
            Connection = new NpgsqlConnection(connectionString);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
