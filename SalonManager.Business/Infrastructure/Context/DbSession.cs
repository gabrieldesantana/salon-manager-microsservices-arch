using Npgsql;
using System.Data;

namespace SalonManager.Business.Infrastructure.Context
{
    public sealed class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration configuration)
        {
            Connection = new NpgsqlConnection(configuration.GetConnectionString("Database"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
