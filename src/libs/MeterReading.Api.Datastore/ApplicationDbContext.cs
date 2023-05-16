using MeterReading.Api.Datastore.Configuration;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Data;

namespace MeterReading.Api.Datastore
{
    public class ApplicationDbContext
    {

        private DatabaseConfiguration _databaseConfiguration;

        public ApplicationDbContext(IOptions<DatabaseConfiguration> databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration.Value;
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_databaseConfiguration.ConnectionString);
        }
    }
}