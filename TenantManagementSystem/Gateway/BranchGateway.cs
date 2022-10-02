using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Gateway
{
    public class BranchGateway : Gateway
    {
        public int Save(Branch aBranch)
        {
            int rowCount = 0;
            try
            {
                Query = "INSERT INTO Branch_tb (Name, CompanyId, Address, Email, Phone, Fax, Cell, RegisterNumber, CreatedBy, CreatedDate) " +
                        "VALUES(@name, @companyid, @address, @email, @phone, @fax, @cell, @registerNumber, @createdBy, @createdDate)";
                Command = new MySqlCommand(Query, Connection);
                // Command.Parameters.AddWithValue("id", aBranch.BranchId);
                Command.Parameters.AddWithValue("name", aBranch.Name);
                Command.Parameters.AddWithValue("CompanyId", Convert.ToString(aBranch.CompanyId));
                Command.Parameters.AddWithValue("address", Convert.ToString(aBranch.Address));
                Command.Parameters.AddWithValue("email", Convert.ToString(aBranch.Email));
                Command.Parameters.AddWithValue("phone", Convert.ToString(aBranch.Phone));
                Command.Parameters.AddWithValue("fax", Convert.ToString(aBranch.Fax));
                Command.Parameters.AddWithValue("cell", Convert.ToString(aBranch.Cell));
                Command.Parameters.AddWithValue("registerNumber", Convert.ToString(aBranch.RegisterNumber));
                Command.Parameters.AddWithValue("createdBy", aBranch.CreatedBy);
                Command.Parameters.AddWithValue("createdDate", aBranch.CreatedDate);
                //Command.Parameters.AddWithValue("updatedBy", aBranch.UpdatedBy);
                //Command.Parameters.AddWithValue("updatedDate", aBranch.UpdatedDate);


                Connection.Open();
                rowCount = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            Connection.Close();
            return rowCount;
        }


        public int Update(Branch aBranch)
        {
            int rowCount = 0;
            try
            {
                Query = "UPDATE Branch_tb SET Name = @name, CompanyId = @companyid, Address = @address, Email = @email, Phone = @phone, " +
                                                            "Fax = @fax, Cell = @cell, RegisterNumber = @registerNumber, UpdatedBy = @updatedBy, " +
                                                            " UpdatedDate = @updatedDate WHERE  Id = @id ";

                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("id", aBranch.BranchId);
                Command.Parameters.AddWithValue("name", aBranch.Name);
                Command.Parameters.AddWithValue("CompanyId", Convert.ToString(aBranch.CompanyId));
                Command.Parameters.AddWithValue("address", Convert.ToString(aBranch.Address));
                Command.Parameters.AddWithValue("email", Convert.ToString(aBranch.Email));
                Command.Parameters.AddWithValue("phone", Convert.ToString(aBranch.Phone));
                Command.Parameters.AddWithValue("fax", Convert.ToString(aBranch.Fax));
                Command.Parameters.AddWithValue("cell", Convert.ToString(aBranch.Cell));
                Command.Parameters.AddWithValue("registerNumber", Convert.ToString(aBranch.RegisterNumber));
                //Command.Parameters.AddWithValue("createdBy", aBranch.CreatedBy);
                //Command.Parameters.AddWithValue("createdDate", aBranch.CreatedDate);
                Command.Parameters.AddWithValue("updatedBy", aBranch.UpdatedBy);
                Command.Parameters.AddWithValue("updatedDate", aBranch.UpdatedDate);


                Connection.Open();
                rowCount = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            return rowCount;
        }
        public List<Branch> GetAllBranch()
        {
            List<Branch> Branch = new List<Branch>();

            try
            {
                Query = "SELECT * FROM Branch_tb";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Branch aBranch = new Branch()
                    {
                        BranchId = Convert.ToInt32(Reader["Id"]),
                        Name = Convert.ToString(Reader["Name"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                        Address = Convert.ToString(Reader["Address"]),
                        Email = Convert.ToString(Reader["Email"]),
                        Phone = Convert.ToString(Reader["Phone"]),
                        Fax = Convert.ToString(Reader["Fax"]),
                        Cell = Convert.ToString(Reader["Cell"]),
                        RegisterNumber = Convert.ToString(Reader["RegisterNumber"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"])
                    };
                    Branch.Add(aBranch);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            Reader.Close();
            return Branch;
        }
    }
}