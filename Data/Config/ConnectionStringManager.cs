using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Data.Config
{
    public class ConnectionStringManager
    {
        private static Dictionary<string, SqlConnection>? Connections { get; set; }
        private readonly IConfiguration configuration;

        public ConnectionStringManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        internal SqlConnection GetSqlConnection(string connectionName)
        {
            if (Connections == null)
            {
                Connections = new Dictionary<string, SqlConnection>();
            }

            Connections.TryGetValue(connectionName, out var conn);

            if (conn == null)
            {
                var connectionString = GetConnectionStringConfigFile(connectionName);
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception($"Check Connection string: {connectionName} in configuration file");
                }
                try
                {
                    conn = new SqlConnection(connectionString);
                } catch
                {
                    throw new Exception($"Check connection string structure of {connectionName}");
                }

                Connections.Add(connectionName, conn);
            }

            return conn;
        }

        private string GetConnectionStringConfigFile(string connectionName)
        {
            var connectionString = configuration.GetConnectionString(connectionName);
            if (connectionString == null)
            {
                throw new Exception($"Connection name {connectionName} don't exists in appsettings");
            }

            return connectionString;
        }
    }
}
