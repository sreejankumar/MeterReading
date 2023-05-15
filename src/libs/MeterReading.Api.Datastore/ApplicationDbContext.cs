using MeterReading.Api.Datastore.Configuration;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Data;

namespace MeterReading.Api.Datastore
{
    public class ApplicationDbContext 
    {
        public IDbConnection Connection;

        private DatabaseConfiguration _databaseConfiguration;

        public ApplicationDbContext(IOptions<DatabaseConfiguration> databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration.Value;
            Connection= CreateConnection();
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_databaseConfiguration.ConnectionString);
        }
        
    }
}