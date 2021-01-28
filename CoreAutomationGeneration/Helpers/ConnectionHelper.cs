using CoreAutomationGeneration.Factory;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CoreAutomationGeneration.Helpers
{
    /// <summary>
    /// Connection Helper Class
    /// </summary>
    public class ConnectionHelper
    {
        /// <summary>
        /// Connections the read for SQL database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="environment">The environment.</param>
        /// <param name="sql">The SQL.</param>
        /// <returns>read connection list</returns>
        public static List<T> ConnectionReadForSqlDatabase<T>(string environment, string sql) where T : class
        {
            using (var connection = ConnectionFactory.SetSqlClientConnection(environment))
            {
                return connection.Query<T>(sql).ToList();
            };
        }

        /// <summary>
        /// Connections the read for SQL database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="environment">The environment.</param>
        /// <param name="sql">The SQL.</param>
        /// <param name="dynamicParam">The dynamic parameter.</param>
        /// <returns>read connection list</returns>
        public static List<T> ConnectionReadForSqlDatabase<T>(string environment, string sql, DynamicParameters dynamicParam) where T : class
        {
            using (var connection = ConnectionFactory.SetSqlClientConnection(environment))
            {
                return connection.Query<T>(sql, dynamicParam).ToList();
            };
        }

        /// <summary>
        /// Connections the execute for SQL database.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        public static void ConnectionExecuteForSqlDatabase(string environment, string sql, object parameters)
        {
            using (var connection = ConnectionFactory.SetSqlClientConnection(environment))
            {
                connection.Execute(sql, parameters);
            };
        }

        /// <summary>
        /// Connections the read map for SQL database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="environment">The environment.</param>
        /// <param name="sql">The SQL.</param>
        /// <returns>read connection list</returns>
        public static List<T> ConnectionReadMapForSqlDatabase<T>(string environment, string sql) where T : class
        {
            SetPropertiesMapToDescription<T>();
            return ConnectionReadForSqlDatabase<T>(environment, sql);
        }

        public static List<T> ConnectionReadMapForSqlDatabase<T>(string environment, string sql, DynamicParameters dynamicParams) where T : class
        {
            SetPropertiesMapToDescription<T>();
            return ConnectionReadForSqlDatabase<T>(environment, sql, dynamicParams);
        }

        /// <summary>
        /// Sets the properties map to description.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void SetPropertiesMapToDescription<T>() where T : class
        {
            var map = new CustomPropertyTypeMap(typeof(T), (type, columnName)
                => type.GetProperties().FirstOrDefault(prop => ConnectionHelper.GetDescriptionFromAttribute(prop) == columnName.ToLower()));

            Dapper.SqlMapper.SetTypeMap(typeof(T), map);
        }

        /// <summary>
        /// Gets the description from attribute.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>attribute description</returns>
        public static string GetDescriptionFromAttribute(MemberInfo member)
        {
            if (member == null) return null;

            var attrib = (DescriptionAttribute)Attribute.GetCustomAttribute(member, typeof(DescriptionAttribute), false);
            return (attrib == null ? member.Name : attrib.Description).ToLower();
        }
    }
}
