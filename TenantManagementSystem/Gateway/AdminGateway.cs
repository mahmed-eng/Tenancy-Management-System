using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Gateway
{
    public class AdminGateway : Gateway
    {
        public int Save(Admin admin)
        {
            Query = "INSERT INTO Admin_tb (Name, UserName, Password, CompanyId, BranchId) VALUES (@n, @un, @pw, @CompanyId, @BranchId)";
            Command = new MySqlCommand(Query, Connection); 
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("n", admin.Name);
            Command.Parameters.AddWithValue("un", admin.UserName);
            Command.Parameters.AddWithValue("pw", admin.Password);
            Command.Parameters.AddWithValue("CompanyId", admin.CompanyId);
            Command.Parameters.AddWithValue("BranchId", admin.BranchId);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }
        public int SaveChangePassword(AdminChangePassowrd admin)
        {
            int rowCount = 0;
            try
            {
                Query = "INSERT INTO Admin_tb (Name,UserName, Password) VALUES (@n,@un, @pw)";

                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("n", admin.Name);
                Command.Parameters.AddWithValue("un", admin.UserName);
                Command.Parameters.AddWithValue("pw", admin.Password);
                Connection.Open();
                rowCount = Command.ExecuteNonQuery();
                Connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowCount;
        }

        public List<Admin> GetAdmin()
        {
            List<Admin> admins = new List<Admin>();
            try
            {
                Query = "SELECT * FROM Admin_tb";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Admin aAdmin = new Admin();

                    aAdmin.Id = Convert.ToInt32(Reader["Id"]);
                    aAdmin.Name = Convert.ToString(Reader["Name"]);
                    aAdmin.UserName = Convert.ToString(Reader["UserName"]);
                    aAdmin.Password = Convert.ToString(Reader["Password"]);
                    aAdmin.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                    aAdmin.BranchId = Convert.ToInt32(Reader["BranchId"]);
                    admins.Add(aAdmin);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            Reader.Close();
            return admins;
        }
    }
}