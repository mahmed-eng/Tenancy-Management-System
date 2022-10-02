using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Gateway
{
    public class LesseeLessorGateway : Gateway
    {
        public int Save(LesseeLessor aLesseeLessor)
        {
            try
            {
                Query = "INSERT INTO LesseeLessor_tb (BranchId, CompanyId, Cardnumber, Name, Peneficiary, Profession, Address, Fax, Phone, Cell, POBox, Email, NOPR, CreatedBy, CreatedDate, RecordType) " +
                                    "VALUES(@branchid, @companyid, @cardnumber, @name, @peneficiary, @profession, @address, @fax, @phone, @cell, @Pobox, @email, @nopr, @createdBy, @createdDate, @recordType)";
                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.Clear();
                //Command.Parameters.AddWithValue("id", aCompany.CompanyId);
                //    Command.Parameters.AddWithValue("id", aLesseeLessor.Id);
                Command.Parameters.AddWithValue("branchid", aLesseeLessor.BranchId);
                Command.Parameters.AddWithValue("companyid", aLesseeLessor.CompanyId);
                Command.Parameters.AddWithValue("cardnumber", aLesseeLessor.CardNumber);
                Command.Parameters.AddWithValue("name", aLesseeLessor.Name);
                Command.Parameters.AddWithValue("peneficiary", aLesseeLessor.Peneficiary);
                Command.Parameters.AddWithValue("profession", aLesseeLessor.Profession);
                Command.Parameters.AddWithValue("address", aLesseeLessor.Address);
                Command.Parameters.AddWithValue("fax", aLesseeLessor.Fax);
                Command.Parameters.AddWithValue("phone", aLesseeLessor.Phone);
                Command.Parameters.AddWithValue("cell", aLesseeLessor.Cell);
                Command.Parameters.AddWithValue("Pobox", aLesseeLessor.POBox);
                Command.Parameters.AddWithValue("email", aLesseeLessor.Email);
                Command.Parameters.AddWithValue("nopr", aLesseeLessor.NOPR);
                Command.Parameters.AddWithValue("createdBy", aLesseeLessor.CreatedBy);
                Command.Parameters.AddWithValue("createdDate", aLesseeLessor.CreatedDate);

                Command.Parameters.AddWithValue("recordtype", aLesseeLessor.RecordType);
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

       //Delete
        public int Delete(LesseeLessor aLesseeLessor)
        {
            try
            {
                Query = "DELETE LesseeLessor SET CompanyId=@companyid, BranchId = @branchid, Cardnumber=@cardnumber, Name=@name, Peneficiary=@peneficiary, " +
                                "Profession=@profession, Address = @address, Fax = @fax, Telephone = @telephone, POBox = @Pobox, Email = @email, " +
                                "NOPR = @nopr, UpdatedBy = @updatedBy, UpdatedDate = @updatedDate, RecordType = @recordType WHERE Id = @id";

                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("id", aLesseeLessor.Id);
                Command.Parameters.AddWithValue("name", aLesseeLessor.Name);
                Command.Parameters.AddWithValue("peneficiary", aLesseeLessor.Peneficiary);
                Command.Parameters.AddWithValue("Profession", aLesseeLessor.Profession);
                Command.Parameters.AddWithValue("address", aLesseeLessor.Address);
                Command.Parameters.AddWithValue("fax", aLesseeLessor.Fax);
                Command.Parameters.AddWithValue("phone", aLesseeLessor.Phone);
                Command.Parameters.AddWithValue("Pobox", aLesseeLessor.POBox);
                Command.Parameters.AddWithValue("email", aLesseeLessor.Email);
                Command.Parameters.AddWithValue("nopr", aLesseeLessor.NOPR);
                Command.Parameters.AddWithValue("updatedBy", string.IsNullOrEmpty(Convert.ToString(aLesseeLessor.UpdatedBy)) ? 0 : Convert.ToInt32(aLesseeLessor.UpdatedBy));
                Command.Parameters.AddWithValue("UpdatedDate", string.IsNullOrEmpty(Convert.ToString(aLesseeLessor.UpdatedDate)) ? DateTime.Now : Convert.ToDateTime(aLesseeLessor.UpdatedDate));
                Command.Parameters.AddWithValue("recordtype", aLesseeLessor.RecordType);
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

        public int Update(LesseeLessor aLesseeLessor)
        {
            int rowCount = 0;

            try
            {

                Query = "UPDATE LesseeLessor_tb SET CompanyId=@companyid, BranchId = @branchid, Cardnumber=@cardnumber, Name=@name, Peneficiary=@peneficiary, " +
               "Profession=@profession, Address = @address, Fax = @fax, Phone = @phone, Cell=@cell, POBox = @Pobox, Email = @email, " +
               "NOPR = @nopr, UpdatedBy = @updatedBy, UpdatedDate = @updatedDate WHERE Id = @id";

                //Query = "UPDATE LesseeLessor_tb SET Name = @name,  Address = @address, CompanyId = @companyid, BranchId = @branchid, Email = @email, Phone = @phone, " +
                //                                            "Fax = @fax, Cell = @cell, UpdatedBy = @updatedBy, " +
                //                                            " UpdatedDate = @updatedDate WHERE  Id = @id ";
                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.AddWithValue("id", aLesseeLessor.Id);
                Command.Parameters.AddWithValue("companyid", aLesseeLessor.CompanyId);
                Command.Parameters.AddWithValue("branchid", aLesseeLessor.BranchId);
                Command.Parameters.AddWithValue("cardnumber", aLesseeLessor.CardNumber);
                Command.Parameters.AddWithValue("peneficiary", aLesseeLessor.Peneficiary);
                Command.Parameters.AddWithValue("profession", aLesseeLessor.Profession);
                Command.Parameters.AddWithValue("pobox", aLesseeLessor.POBox);
                Command.Parameters.AddWithValue("name", aLesseeLessor.Name);
                Command.Parameters.AddWithValue("address", aLesseeLessor.Address);
                Command.Parameters.AddWithValue("email", aLesseeLessor.Email);
                Command.Parameters.AddWithValue("phone", aLesseeLessor.Phone);
                Command.Parameters.AddWithValue("fax", aLesseeLessor.Fax);
                Command.Parameters.AddWithValue("cell", aLesseeLessor.Cell);
                Command.Parameters.AddWithValue("nopr", aLesseeLessor.NOPR);
               // Command.Parameters.AddWithValue("recordtype", aLesseeLessor.RecordType);
                //Command.Parameters.AddWithValue("registerNumber", aLesseeLessor.RegisterNumber);
                Command.Parameters.AddWithValue("updatedBy", aLesseeLessor.UpdatedBy);
                Command.Parameters.AddWithValue("updatedDate", aLesseeLessor.UpdatedDate);


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


        public List<LesseeLessor> GetAllLesseeLessor()
        {
            List<LesseeLessor> LesseeLessor = new List<LesseeLessor>();
            try
            {
                Query = "SELECT * FROM LesseeLessor_tb";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    LesseeLessor aLesseeLessor = new LesseeLessor()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                        BranchId = Convert.ToInt32(Reader["BranchId"]),
                        CardNumber = Convert.ToString(Reader["CardNumber"]),
                        Name = Convert.ToString(Reader["Name"]),
                        Peneficiary = string.IsNullOrEmpty(Convert.ToString(Reader["Peneficiary"])) ? string.Empty : Convert.ToString(Reader["Peneficiary"]),
                        Profession = string.IsNullOrEmpty(Convert.ToString(Reader["Profession"])) ? string.Empty : Convert.ToString(Reader["Profession"]),
                        Address = string.IsNullOrEmpty(Convert.ToString(Reader["Address"])) ? string.Empty : Convert.ToString(Reader["Address"]),
                        Fax = string.IsNullOrEmpty(Convert.ToString(Reader["Fax"])) ? string.Empty : Convert.ToString(Reader["Fax"]),
                        Phone = string.IsNullOrEmpty(Convert.ToString(Reader["Phone"])) ? string.Empty : Convert.ToString(Reader["Phone"]),
                        Cell = string.IsNullOrEmpty(Convert.ToString(Reader["Cell"])) ? string.Empty : Convert.ToString(Reader["Cell"]),
                        POBox = string.IsNullOrEmpty(Convert.ToString(Reader["POBox"])) ? string.Empty : Convert.ToString(Reader["POBox"]),
                        Email = string.IsNullOrEmpty(Convert.ToString(Reader["Email"])) ? string.Empty : Convert.ToString(Reader["Email"]),
                        NOPR = string.IsNullOrEmpty(Convert.ToString(Reader["NOPR"])) ? 0 : Convert.ToInt32(Reader["NOPR"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"]),
                        RecordType = Convert.ToInt32(Reader["RecordType"])

                    };
                    LesseeLessor.Add(aLesseeLessor);
                }
                Connection.Close();
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LesseeLessor;
        }
    }
}