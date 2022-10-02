using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Gateway
{
    public class AreaGateway : Gateway
    {
        public int Save(Area aArea)
        {
            int rowCount = 0;
            try
            {


                Query = "INSERT INTO Area_tb (Name, companyid, branchid, cityid, createdBy, createdDate) " +
                        "VALUES(@name, @companyid, @branchid, @cityid, @createdBy, @createdDate)";
                Command = new MySqlCommand(Query, Connection);
                //Command.Parameters.AddWithValue("id", aArea.Id);
                Command.Parameters.AddWithValue("name", aArea.Name);
                Command.Parameters.AddWithValue("companyid", Convert.ToString(aArea.CompanyId));
                Command.Parameters.AddWithValue("branchid", Convert.ToString(aArea.BranchId));
                Command.Parameters.AddWithValue("cityid", Convert.ToString(aArea.CityId));
                //Command.Parameters.AddWithValue("countryid", Convert.ToString(aArea.CountryId));    
                Command.Parameters.AddWithValue("createdBy", aArea.CreatedBy);
                Command.Parameters.AddWithValue("createdDate", aArea.CreatedDate);

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

        public int Update(Area aArea)
        {
            int rowCount = 0;

            try
            {


                Query = "UPDATE Area_tb SET Name = @name, CompanyId = @companyid, CityId = @cityid, BranchId = @branchid, " +
                                                            "UpdatedBy = @updatedBy, " +
                                                            " UpdatedDate = @updatedDate WHERE  Id = @id ";
                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.AddWithValue("id", aArea.Id);
                Command.Parameters.AddWithValue("companyid", aArea.CompanyId);
                Command.Parameters.AddWithValue("cityid", aArea.CityId);
                Command.Parameters.AddWithValue("branchid", aArea.BranchId);
                Command.Parameters.AddWithValue("name", aArea.Name);
                Command.Parameters.AddWithValue("updatedBy", aArea.UpdatedBy);
                Command.Parameters.AddWithValue("updatedDate", aArea.UpdatedDate);


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


        public List<Area> GetAllArea()
        {
            List<Area> Area = new List<Area>();
            try
            {
                Query = "SELECT a.id, a.companyid,a.cityid, a.branchid, a.name, a.createdby, a.createddate, a.updatedby, a.updateddate, " +
                    "               c.name cityname" +
                    "                  FROM area_tb a inner join city_tb c on a.cityid = c.id";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Area aArea = new Area()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        Name = Convert.ToString(Reader["Name"]),
                        CityName = Convert.ToString(Reader["CityName"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                        BranchId = Convert.ToInt32(Reader["BranchId"]),
                        CityId = Convert.ToInt32(Reader["CityId"]),
                        //CountryId = Convert.ToInt32(Reader["CountryId"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"])
                    };
                    Area.Add(aArea);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            Reader.Close();
            return Area;
        }
    }
}