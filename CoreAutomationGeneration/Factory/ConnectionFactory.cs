using CoreAutomationGeneration.DBConnections.DataSettings;
using System;
using System.Data;
using System.Linq.Expressions;

namespace CoreAutomationGeneration.Factory
{
    /// <summary>
    /// Connection Factory Class
    /// </summary>
    public class ConnectionFactory
    {
        /// <summary>
        /// Sets the SQL client connection.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <returns>The sql client connection</returns>
        public static IDbConnection SetSqlClientConnection(string environment)
        {
            string connectionString = $"{nameof(DbConnectionStrings)}:{environment}:{nameof(DbConnectionStrings.ConnectionString)}";
            string connectionStringFromJson = LoaderFactory.Instance.Configuration.GetSection(connectionString).Value;
            return new System.Data.SqlClient.SqlConnection(connectionStringFromJson);
        }
    }
}
