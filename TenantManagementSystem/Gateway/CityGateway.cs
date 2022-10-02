using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Gateway
{
    public class CityGateway : Gateway
    {
        public int Save(City aCity)
        {
            int rowCount = 0;
            try
            {


                Query = "INSERT INTO City_tb (Name, companyid, branchid,createdBy, createdDate) " +
                        "VALUES(@name, @companyid, @branchid, @createdBy, @createdDate)";
                Command = new MySqlCommand(Query, Connection);
                //Command.Parameters.AddWithValue("id", aCity.Id);
                Command.Parameters.AddWithValue("name", aCity.Name);
                Command.Parameters.AddWithValue("companyid", Convert.ToString(aCity.CompanyId));
                Command.Parameters.AddWithValue("branchid", Convert.ToString(aCity.BranchId));
                //Command.Parameters.AddWithValue("countryid", Convert.ToString(aCity.CountryId));    
                Command.Parameters.AddWithValue("createdBy", aCity.CreatedBy);
                Command.Parameters.AddWithValue("createdDate", aCity.CreatedDate);

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

        public int Update(City aCity)
        {
            int rowCount = 0;

            try
            {


                Query = "UPDATE City_tb SET Name = @name, CompanyId = @companyid, BranchId = @branchid, " +
                                                            "UpdatedBy = @updatedBy, " +
                                                            " UpdatedDate = @updatedDate WHERE  Id = @id ";
                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.AddWithValue("id", aCity.Id);
                Command.Parameters.AddWithValue("companyid", aCity.CompanyId);
                Command.Parameters.AddWithValue("branchid", aCity.BranchId);
                Command.Parameters.AddWithValue("name", aCity.Name);
                //Command.Parameters.AddWithValue("address", aCity.Address);
                //Command.Parameters.AddWithValue("email", aCity.Email);
                //Command.Parameters.AddWithValue("phone", aCity.Phone);
                //Command.Parameters.AddWithValue("fax", aCity.Fax);
                //Command.Parameters.AddWithValue("cell", aCity.Cell);
                //Command.Parameters.AddWithValue("registerNumber", aCity.RegisterNumber);
                Command.Parameters.AddWithValue("updatedBy", aCity.UpdatedBy);
                Command.Parameters.AddWithValue("updatedDate", aCity.UpdatedDate);


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


        public List<City> GetAllCity()
        {
            List<City> City = new List<City>();
            try
            {
                Query = "SELECT * FROM City_tb";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    City aCity = new City()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        Name = Convert.ToString(Reader["Name"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                        BranchId = Convert.ToInt32(Reader["BranchId"]),
                        //CountryId = Convert.ToInt32(Reader["CountryId"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"])
                    };
                    City.Add(aCity);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            Reader.Close();
            return City;
        }
    }
}