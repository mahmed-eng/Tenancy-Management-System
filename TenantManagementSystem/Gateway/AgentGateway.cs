using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Gateway
{
    public class AgentGateway : Gateway
    {
        public int Save(Agent aAgent)
        {
            try
            {
                Query = "INSERT INTO Agent_tb (Name, companyid, branchid, Address, Email, Phone, Fax, Cell, createdBy, createdDate) " +
                                    "VALUES(@name, @companyid, @branchid, @address, @email, @phone, @fax, @cell, @createdBy, @createdDate)";
                Command = new MySqlCommand(Query, Connection);
                //Command.Parameters.AddWithValue("id", aAgent.Id);
                Command.Parameters.AddWithValue("name", aAgent.Name);
                Command.Parameters.AddWithValue("companyid", Convert.ToString(aAgent.CompanyId));
                Command.Parameters.AddWithValue("branchid", Convert.ToString(aAgent.BranchId));
                Command.Parameters.AddWithValue("address", Convert.ToString(aAgent.Address));
                Command.Parameters.AddWithValue("email", Convert.ToString(aAgent.Email));
                Command.Parameters.AddWithValue("phone", Convert.ToString(aAgent.Phone));
                Command.Parameters.AddWithValue("fax", Convert.ToString(aAgent.Fax));
                Command.Parameters.AddWithValue("cell", Convert.ToString(aAgent.Cell));
                Command.Parameters.AddWithValue("createdBy", aAgent.CreatedBy);
                Command.Parameters.AddWithValue("createdDate", aAgent.CreatedDate);
                //Command.Parameters.AddWithValue("updatedBy", aAgent.UpdatedBy);
                //Command.Parameters.AddWithValue("updatedDate", aAgent.UpdatedDate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public int Update(Agent aAgent)
        {
            int rowCount = 0;

            try
            {
                Query = "UPDATE Agent_tb SET Name = @name,  Address = @address, CompanyId = @companyid, BranchId = @branchid, Email = @email, Phone = @phone, " +
                                                            "Fax = @fax, Cell = @cell, UpdatedBy = @updatedBy, " +
                                                            " UpdatedDate = @updatedDate WHERE  Id = @id ";
                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.AddWithValue("id", aAgent.Id);
                Command.Parameters.AddWithValue("companyid", aAgent.CompanyId);
                Command.Parameters.AddWithValue("branchid", aAgent.BranchId);
                Command.Parameters.AddWithValue("name", aAgent.Name);
                Command.Parameters.AddWithValue("address", aAgent.Address);
                Command.Parameters.AddWithValue("email", aAgent.Email);
                Command.Parameters.AddWithValue("phone", aAgent.Phone);
                Command.Parameters.AddWithValue("fax", aAgent.Fax);
                Command.Parameters.AddWithValue("cell", aAgent.Cell);
                //Command.Parameters.AddWithValue("registerNumber", aAgent.RegisterNumber);
                Command.Parameters.AddWithValue("updatedBy", aAgent.UpdatedBy);
                Command.Parameters.AddWithValue("updatedDate", aAgent.UpdatedDate);


                Connection.Open();
                rowCount = Command.ExecuteNonQuery();
                rowCount = 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            Connection.Close();
            return rowCount;
        }


        public List<Agent> GetAllAgent()
        {
            List<Agent> Agent = new List<Agent>();
            try
            {
                Query = "SELECT * FROM Agent_tb";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Agent aAgent = new Agent()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        Name = Convert.ToString(Reader["Name"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                        BranchId = Convert.ToInt32(Reader["BranchId"]),
                        Address = Convert.ToString(Reader["Address"]),
                        Email = Convert.ToString(Reader["Email"]),
                        Phone = Convert.ToString(Reader["Phone"]),
                        Fax = Convert.ToString(Reader["Fax"]),
                        Cell = Convert.ToString(Reader["Cell"]),
                        CreatedBy = Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"])
                    };
                    Agent.Add(aAgent);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            Reader.Close();
            return Agent;
        }
    }
}