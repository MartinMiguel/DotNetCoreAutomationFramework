
using System.Configuration;
using System.Data;

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
            string configurationEnvironment = ConfigurationManager.ConnectionStrings[environment].ConnectionString;
            return new System.Data.SqlClient.SqlConnection(configurationEnvironment);
        }
    }
}
