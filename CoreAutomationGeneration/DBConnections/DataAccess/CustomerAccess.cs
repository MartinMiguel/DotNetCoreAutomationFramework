using System.Collections.Generic;
using CoreAutomationGeneration.DataConnections.DataModels;
using CoreAutomationGeneration.Helpers;
using Dapper;

namespace CoreAutomationGeneration.DBConnections.DataAccess
{
    /// <summary>
    /// The data access class
    /// </summary>
    public class CustomerAccess
    {
        public const string env = "Test";

        /// <summary>
        /// Gets the customers information from database.
        /// </summary>
        /// <returns>The customers info list</returns>
        public static List<Customer> GetCustomersInfoFromDB()
        {
            //Need to match data model properties to table names
            string sql = "SELECT " +
                "customer_id AS CustomerID, " +
                "first_name AS FirstName, " +
                "last_name AS LastName, " +
                "phone AS Phone, " +
                "email_address AS EmailAddress " +
                "FROM test_db.dbo.customer_info";
            return ConnectionHelper.ConnectionReadForSqlDatabase<Customer>(env, sql);
        }

        /// <summary>
        /// Gets the mapped customers information from database
        /// </summary>
        /// <returns>The customers info list</returns>
        public static List<Customer> GetMappedCustomersInfoFromDB()
        {
            //No need to match data model properties to table names
            string sql = "SELECT * FROM test_db.dbo.customer_info";
            return ConnectionHelper.ConnectionReadMapForSqlDatabase<Customer>(env, sql);
        }

        /// <summary>
        /// Gets the last name of the customers by.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <returns>The customers info by last name list</returns>
        public static List<Customer> GetCustomersByLastName(string lastName)
        {
            var customer = new DynamicParameters();
            customer.Add("@LastName", lastName);
            //Execute store procedure with parameter and read results from db
            string sql = "dbo.GetCustomerInfoByLastName @LastName";
            return ConnectionHelper.ConnectionReadMapForSqlDatabase<Customer>(env, sql, customer);
        }

        /// <summary>
        /// Inserts the new customer.
        /// </summary>
        /// <param name="customer_ID">The customer identifier.</param>
        /// <param name="first_Name">The first name.</param>
        /// <param name="last_Name">The last name.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="email_address">The email address.</param>
        public static void InsertNewCustomer(int customer_ID, string first_Name, string last_Name, string phone, string email_address)
        {
            var customer = new
            {
                customerID = customer_ID,
                firstName = first_Name,
                lastName = last_Name,
                Phone = phone,
                email = email_address
            };

            string sql = $@"dbo.InsertCustomer @CustomerID, @FirstName, @LastName, @Phone, @EmailAddress";
            ConnectionHelper.ConnectionExecuteForSqlDatabase(env, sql, customer);
        }
    }
}
