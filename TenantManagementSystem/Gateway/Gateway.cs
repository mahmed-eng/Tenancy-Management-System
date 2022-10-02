using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace TenantManagementSystem.Gateway
{
    public class Gateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["U_DB"].ConnectionString;
        public MySql.Data.MySqlClient.MySqlConnection Connection { get; set; }
        public MySqlCommand Command { get; set; }
        public MySqlDataReader Reader { get; set; }
        public string Query { get; set; }

        public Gateway()
        {
            Connection = new MySqlConnection(connectionString);
        }
    }
}