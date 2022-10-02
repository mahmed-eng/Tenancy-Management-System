using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Gateway
{
    public class PropertyGateway : Gateway
    {
        public int Save(Property aProperty)
        {
            try
            {
                Query = "INSERT INTO Property_tb (BuildingId, CityId, Propertynumber, Name, PropertyType, Street, LessorId, PilotNumber, BondNumber,  Address, CreatedBy, CreatedDate, " +
                    "                           BondType, CompanyId, BranchId, AreaId, FlatTypeId) " +
                                    "VALUES(@buildingid, @cityid, @propertynumber, @name, @propertytype, @street, @lessorid, @pilotnumber, @bondnumber, @address, @createdBy, @createdDate, " +
                                    "       @bondType, @companyId, @branchId, @areaid, @flatTypeId)";

                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("id", aProperty.Id);
                Command.Parameters.AddWithValue("areaid", aProperty.AreaId);
                Command.Parameters.AddWithValue("CityId", aProperty.CityId);
                Command.Parameters.AddWithValue("lessorid", aProperty.LessorId);
                Command.Parameters.AddWithValue("propertynumber", aProperty.PropertyNumber);
                Command.Parameters.AddWithValue("propertytype", aProperty.PropertyType);
                Command.Parameters.AddWithValue("street", aProperty.Street);
                Command.Parameters.AddWithValue("pilotnumber", aProperty.PilotNumber);
                Command.Parameters.AddWithValue("governmentnumber", aProperty.GovernmentNumber);
                Command.Parameters.AddWithValue("bondnumber", aProperty.BondNumber);
                Command.Parameters.AddWithValue("buildingid", aProperty.BuildingId);
                Command.Parameters.AddWithValue("name", aProperty.Name);
                Command.Parameters.AddWithValue("address", aProperty.Address);
                Command.Parameters.AddWithValue("createdBy", aProperty.CreatedBy);
                Command.Parameters.AddWithValue("createdDate", aProperty.CreatedDate);
                Command.Parameters.AddWithValue("bondtype", aProperty.BondType);
                Command.Parameters.AddWithValue("companyId", aProperty.CompanyId);
                Command.Parameters.AddWithValue("branchId", aProperty.BranchId);
                Command.Parameters.AddWithValue("flatTypeId", aProperty.FlatTypeId);

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
        public int Delete(Property aProperty)
        {
            Query = "DELETE Property SET CompanyId=@companyid, BranchId = @branchid, Cardnumber=@cardnumber, Name=@name, Peneficiary=@peneficiary, " +
                "Profession=@profession, Address = @address, Fax = @fax, Telephone = @telephone, POBox = @Pobox, Email = @email, " +
                "NOPR = @nopr, UpdatedBy = @updatedBy, UpdatedDate = @updatedDate, RecordType = @recordType WHERE Id = @id";

            Command = new MySqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("id", aProperty.Id);
            Command.Parameters.AddWithValue("name", aProperty.Name);
            Command.Parameters.AddWithValue("address", aProperty.Address);
            Command.Parameters.AddWithValue("updatedBy", string.IsNullOrEmpty(Convert.ToString(aProperty.UpdatedBy)) ? 0 : Convert.ToInt32(aProperty.UpdatedBy));
            Command.Parameters.AddWithValue("UpdatedDate", string.IsNullOrEmpty(Convert.ToString(aProperty.UpdatedDate)) ? DateTime.Now : Convert.ToDateTime(aProperty.UpdatedDate));
            Command.Parameters.AddWithValue("recordtype", aProperty.BondType);


            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public int Update(Property aProperty)
        {
            int rowCount = 0;

            try
            {

                Query = "UPDATE Property_tb SET BuildingId=@buildingid, CityId = @cityid, Name=@name, areaid = @areaid, " +
               "Street=@street, Address = @address, LessorId = @lessorid," +
               "UpdatedBy = @updatedBy, UpdatedDate = @updatedDate WHERE Id = @id";

                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.AddWithValue("id", aProperty.Id);
                Command.Parameters.AddWithValue("areaid", aProperty.AreaId);
                Command.Parameters.AddWithValue("CityId", aProperty.CityId);
                Command.Parameters.AddWithValue("lessorid", aProperty.LessorId);
                Command.Parameters.AddWithValue("buildingid", aProperty.BuildingId);
                Command.Parameters.AddWithValue("name", aProperty.Name);
                Command.Parameters.AddWithValue("street", aProperty.Street);
                Command.Parameters.AddWithValue("address", aProperty.Address);
                Command.Parameters.AddWithValue("updatedBy", aProperty.UpdatedBy);
                Command.Parameters.AddWithValue("updatedDate", aProperty.UpdatedDate);


                Connection.Open();
                rowCount = Command.ExecuteNonQuery();
                Connection.Close();
                rowCount = 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //Connection.Close();
            return rowCount;
        }


        public List<Property> GetAllProperty()
        {
            List<Property> propertyList = new List<Property>();
            try
            {
                //Query = "SELECT * FROM Property_tb";
                Query = "SELECT P.ID, P.PropertyNumber, P.CompanyId, P.BranchId, P.AreaId, A.Name As AreaName, P.PropertyType, P.CityId, " +
                        " C.NAme as CityName,  " +
                        " CASE WHEN  P.PropertyType = 0 THEN 'Building' WHEN P.PropertyType = 1 THEN 'Vellas'  " +
                        " WHEN P.PropertyType = 2 THEN 'Flat'    ELSE 'Shop'  END 'PropertyTypeName',    " +
                        " P.NAME AS 'Name',  P.LessorId, L.NAME 'LessorName', P.BuildingId, B.Name AS 'BuildingName', P.FlatTypeId,  " +
                        "CASE " +
                            "WHEN P.FlatTypeId = 1 THEN 'Studio' " +
                            "WHEN P.FlatTypeId = 2 THEN '1 BHK' " +
                            "WHEN P.FlatTypeId = 3 THEN '2 BHK' " +
                            "WHEN P.FlatTypeId = 4 THEN '3 BHK' " +
                            "WHEN P.FlatTypeId = 5 THEN '4 BHK' " +
                            "WHEN P.FlatTypeId = 6 THEN 'Paint House' " +
                            "ELSE 'None' END 'FlatTypeName', "+
                        " P.BondType, P.BondNumber, P.GovernmentNumber, P.PilotNumber, P.Street, P.Address, P.CreatedBy, P.CreatedDate, P.UpdatedBy, P.UpdatedDate " +
                        " FROM Property_tb AS P  " +
                        " left JOIN LesseeLessor_tb AS L ON P.LessorId = L.Id  " +
                        " left JOIN Property_tb AS B ON P.BuildingId = B.Id  " +
                        " left JOIN City_tb AS C ON P.CityId = C.Id  " +
                        "  left JOIN Area_tb AS A ON P.AreaId = A.Id ORDER BY P.PropertyType";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Property aProperty = new Property()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        CityId = Convert.ToInt32(Reader["CityId"]),
                        CityName = Convert.ToString(Reader["CityName"]),
                        BuildingId = Convert.ToInt32(Reader["BuildingId"]),
                        BuildingName = Convert.ToString(Reader["BuildingName"]),
                        AreaId = Convert.ToInt32(Reader["AreaId"]),
                        AreaName = Convert.ToString(Reader["AreaName"]),
                        LessorId = Convert.ToInt32(Reader["LessorId"]),
                        LessorName = Convert.ToString(Reader["LessorName"]),
                        PropertyNumber = Convert.ToString(Reader["PropertyNumber"]),
                        Name = Convert.ToString(Reader["Name"]),
                         FlatNo = Convert.ToString(Reader["Name"]),
                        Address = Convert.ToString(Reader["Address"]),
                        BondNumber = Convert.ToString(Reader["BondNumber"]),
                        GovernmentNumber = Convert.ToString(Reader["GovernmentNumber"]),
                        PilotNumber = Convert.ToString(Reader["PilotNumber"]),
                        Street = Convert.ToString(Reader["Street"]),
                        PropertyType = Convert.ToInt32(Reader["PropertyType"]),
                        PropertyTypeName = Convert.ToString(Reader["PropertyTypeName"]),
                        FlatTypeId = string.IsNullOrEmpty(Convert.ToString(Reader["FlatTypeId"])) ? 0 : Convert.ToInt32(Reader["FlatTypeId"]),
                        FlatTypeName = Convert.ToString(Reader["FlatTypeName"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"]),
                        BondType = Convert.ToString(Reader["BondType"])
                    };
                    propertyList.Add(aProperty);
                }
                Connection.Close();
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propertyList;
        }


        public List<Property> GetAllPropertyUO()
        {
            List<Property> propertyList = new List<Property>();
            try
            {
                //Query = "SELECT * FROM Property_tb";
                //Query = "SELECT P.ID, P.PropertyNumber, P.CompanyId, P.BranchId, P.AreaId, A.Name As AreaName, P.PropertyType, P.CityId, " +
                //        " C.NAme as CityName,  " +
                //        " CASE WHEN  P.PropertyType = 0 THEN 'Building' WHEN P.PropertyType = 1 THEN 'Vellas'  " +
                //        " WHEN P.PropertyType = 2 THEN 'Flat'    ELSE 'Shop'  END 'PropertyTypeName',    " +
                //        " P.NAME AS 'Name',  P.LessorId, L.NAME 'LessorName', P.BuildingId, B.Name AS 'BuildingName', P.FlatTypeId,  " +
                //        " CASE WHEN P.FlatTypeId = 1 THEN 'Studio' WHEN P.FlatTypeId = 2 THEN '2 BHK' WHEN P.FlatTypeId = 3 THEN '3 BHK'  " +
                //        " WHEN P.FlatTypeId = 4 THEN '4 BHK'  " +
                //        " WHEN P.FlatTypeId = 5 THEN 'Paint House' ELSE 'None' END 'FlatTypeName',  " +
                //        " P.BondType, P.BondNumber, P.GovernmentNumber, P.PilotNumber, P.Street, P.Address, P.CreatedBy, P.CreatedDate, P.UpdatedBy, P.UpdatedDate " +
                //        " FROM Property_tb AS P  " +
                //        " left JOIN LesseeLessor_tb AS L ON P.LessorId = L.Id  " +
                //        " left JOIN Property_tb AS B ON P.BuildingId = B.Id  " +
                //        " left JOIN City_tb AS C ON P.CityId = C.Id  " +
                //        "  left JOIN Area_tb AS A ON P.AreaId = A.Id WHERE P.ID not IN (select FlatId from tenancyagreement_tb WHERE IsCompleted=0 OR IsCancelled=0 ) " +
                //        " ORDER BY P.PropertyType";

                Query = " SELECT BLD.Id, BLD.PropertyNumber, TA.AgreementNumber, BLD.LessorId, LSR.Name LessorName,  TA.LesseeId, LSE.Name LesseeName, " +
                    " LSR.Cell LessorCell,  LSE.Cell LesseeCell, " +
                    " BLD.PropertyType, CASE WHEN  BLD.PropertyType = 0 THEN 'Building' WHEN BLD.PropertyType = 1 THEN 'Vellas'  " +
                    " WHEN BLD.PropertyType = 2 THEN 'Flat'    ELSE 'Shop'  END 'PropertyTypeName',    " +
                    "   FLT.BuildingId, BLD.Name BuildingName,  FLT.Id FlatId, FLT.Name FlatNo, DATE_FORMAT(TA.StartDate, '%d-%b-%Y') StartDateDetail,  " +
                    "  DATE_FORMAT(TA.EndDate, '%d-%b-%Y') EndDateDetail, TA.StartDate, TA.EndDate,  TA.RentDurationinDays, TA.RentDurationinMonths, " +
                    "  TA.MonthlyAmount, TA.TotalAmount, TA.IsStarted, TA.IsCompleted, TA.IsCancelled, FLT.FlatTypeId,  " +
                    "  CASE WHEN FLT.FlatTypeId = 1 THEN 'Studio' WHEN FLT.FlatTypeId = 2 THEN '1 BHK' WHEN FLT.FlatTypeId = 3 THEN '2 BHK' " +
                    "  WHEN FLT.FlatTypeId = 4 THEN '3 BHK' WHEN FLT.FlatTypeId = 5 THEN '4 BHK' " +
                    "  WHEN FLT.FlatTypeId = 6 THEN 'Paint House' ELSE 'None' END 'FlatTypeName', " +
                    "  BLD.AreaId, A.Name As AreaName, BLD.CityId, C.NAme as CityName," +
                    "  BLD.BondType, BLD.BondNumber, BLD.GovernmentNumber, BLD.PilotNumber, BLD.Street, BLD.Address, BLD.CreatedBy, BLD.CreatedDate, BLD.UpdatedBy, BLD.UpdatedDate" +
                    " FROM property_tb BLD " +
                    "  LEFT JOIN property_tb FLT ON FLT.BuildingId = BLD.Id " +
                    " LEFT JOIN tenancyagreement_tb TA ON BLD.Id = TA.BuildingId AND TA.FlatId = FLT.Id " +
                    " LEFT JOIN LESSEELESSOR_TB LSR ON BLD.LessorId = LSR.Id " +
                    " LEFT JOIN LESSEELESSOR_TB LSe ON TA.LesseeId = LSE.Id " +
                    " LEFT JOIN City_tb AS C ON BLD.CityId = C.Id " +
                    " LEFT JOIN Area_tb AS A ON BLD.AreaId = A.Id " +
                    " WHERE (FLT.ID NOT IN (select FlatId from tenancyagreement_tb WHERE IsCompleted=0 OR IsCancelled=0 )) " +
                    " ORDER BY BLD.PropertyType";

                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Property aProperty = new Property()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        CityId = string.IsNullOrEmpty(Convert.ToString(Reader["CityId"])) ? 0 : Convert.ToInt32(Reader["CityId"]),
                        CityName = Convert.ToString(Reader["CityName"]),
                        BuildingId = string.IsNullOrEmpty(Convert.ToString(Reader["BuildingId"])) ? 0 : Convert.ToInt32(Reader["BuildingId"]),
                        BuildingName = Convert.ToString(Reader["BuildingName"]),
                        AreaId = string.IsNullOrEmpty(Convert.ToString(Reader["AreaId"])) ? 0 : Convert.ToInt32(Reader["AreaId"]),
                        AreaName = Convert.ToString(Reader["AreaName"]),
                        LessorId = string.IsNullOrEmpty(Convert.ToString(Reader["LessorId"])) ? 0 : Convert.ToInt32(Reader["LessorId"]),
                        LessorName = Convert.ToString(Reader["LessorName"]),
                        PropertyNumber = Convert.ToString(Reader["PropertyNumber"]),
                        Name = Convert.ToString(Reader["BuildingName"]),
                        FlatNo = Convert.ToString(Reader["FlatNo"]),
                        FlatId = string.IsNullOrEmpty(Convert.ToString(Reader["FlatId"])) ? 0 : Convert.ToInt32(Reader["FlatId"]),
                        Address = Convert.ToString(Reader["Address"]),
                        BondNumber = Convert.ToString(Reader["BondNumber"]),
                        GovernmentNumber = Convert.ToString(Reader["GovernmentNumber"]),
                        PilotNumber = Convert.ToString(Reader["PilotNumber"]),
                        Street = Convert.ToString(Reader["Street"]),
                        PropertyType = string.IsNullOrEmpty(Convert.ToString(Reader["PropertyType"])) ? 0 : Convert.ToInt32(Reader["PropertyType"]),
                        PropertyTypeName = Convert.ToString(Reader["PropertyTypeName"]),
                        FlatTypeId = string.IsNullOrEmpty(Convert.ToString(Reader["FlatTypeId"])) ? 0 : Convert.ToInt32(Reader["FlatTypeId"]),
                        FlatTypeName = Convert.ToString(Reader["FlatTypeName"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"]),
                        BondType = Convert.ToString(Reader["BondType"]),
                        AgreementNumber = Convert.ToString(Reader["AgreementNumber"]),
                        StartDate = Convert.ToString(Reader["StartDateDetail"]),
                        EndDate = Convert.ToString(Reader["EndDateDetail"]),
                        LesseeName = Convert.ToString(Reader["LesseeName"]),
                        LesseeCellNo = Convert.ToString(Reader["LesseeCell"]),
                        LesssorCellNo = Convert.ToString(Reader["LessorCell"]),
                        AgreementAmount = string.IsNullOrEmpty(Convert.ToString(Reader["TotalAmount"])) ? 0 : Convert.ToDecimal(Reader["TotalAmount"])
                    };
                    propertyList.Add(aProperty);
                }
                Connection.Close();
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propertyList;
        }

        public List<Property> GetAllPropertyO()
        {
            List<Property> propertyList = new List<Property>();
            try
            {
                //Query = "SELECT * FROM Property_tb";
                //Query = "SELECT P.ID, P.PropertyNumber, P.CompanyId, P.BranchId, P.AreaId, A.Name As AreaName, P.PropertyType, P.CityId, " +
                //        " C.NAme as CityName,  " +
                //        " CASE WHEN  P.PropertyType = 0 THEN 'Building' WHEN P.PropertyType = 1 THEN 'Vellas'  " +
                //        " WHEN P.PropertyType = 2 THEN 'Flat'    ELSE 'Shop'  END 'PropertyTypeName',    " +
                //        " P.NAME AS 'Name',  P.LessorId, L.NAME 'LessorName', P.BuildingId, B.Name AS 'BuildingName', P.FlatTypeId,  " +
                //        " CASE WHEN P.FlatTypeId = 1 THEN 'Studio' WHEN P.FlatTypeId = 2 THEN '2 BHK' WHEN P.FlatTypeId = 3 THEN '3 BHK'  " +
                //        " WHEN P.FlatTypeId = 4 THEN '4 BHK'  " +
                //        " WHEN P.FlatTypeId = 5 THEN 'Paint House' ELSE 'None' END 'FlatTypeName',  " +
                //        " P.BondType, P.BondNumber, P.GovernmentNumber, P.PilotNumber, P.Street, P.Address, P.CreatedBy, P.CreatedDate, P.UpdatedBy, P.UpdatedDate " +
                //        " FROM Property_tb AS P  " +
                //        " left JOIN LesseeLessor_tb AS L ON P.LessorId = L.Id  " +
                //        " left JOIN Property_tb AS B ON P.BuildingId = B.Id  " +
                //        " left JOIN City_tb AS C ON P.CityId = C.Id  " +
                //        "  left JOIN Area_tb AS A ON P.AreaId = A.Id WHERE P.ID IN (select FlatId from tenancyagreement_tb)  ORDER BY P.PropertyType  ";

                Query = " SELECT BLD.Id, BLD.PropertyNumber, TA.AgreementNumber, BLD.LessorId, LSR.Name LessorName,  TA.LesseeId, LSE.Name LesseeName, " +
                   " LSR.Cell LessorCell,  LSE.Cell LesseeCell, " +
                   " BLD.PropertyType, CASE WHEN  BLD.PropertyType = 0 THEN 'Building' WHEN BLD.PropertyType = 1 THEN 'Vellas'  " +
                   " WHEN BLD.PropertyType = 2 THEN 'Flat'    ELSE 'Shop'  END 'PropertyTypeName',    " +
                   "   TA.BuildingId, BLD.Name BuildingName, TA.FlatId, FLT.Name FlatNo, DATE_FORMAT(TA.StartDate, '%d-%b-%Y') StartDateDetail,  " +
                   "  DATE_FORMAT(TA.EndDate, '%d-%b-%Y') EndDateDetail, TA.StartDate, TA.EndDate,  TA.RentDurationinDays, TA.RentDurationinMonths, " +
                   "  TA.MonthlyAmount, TA.TotalAmount, TA.IsStarted, TA.IsCompleted, TA.IsCancelled, FLT.FlatTypeId,  " +
                   "  CASE WHEN FLT.FlatTypeId = 1 THEN 'Studio' WHEN FLT.FlatTypeId = 2 THEN '1 BHK' WHEN FLT.FlatTypeId = 3 THEN '2 BHK' " +
                   "  WHEN FLT.FlatTypeId = 4 THEN '3 BHK' WHEN FLT.FlatTypeId = 5 THEN '4 BHK' " +
                   "  WHEN FLT.FlatTypeId = 6 THEN 'Paint House' ELSE 'None' END 'FlatTypeName', " +
                   "  BLD.AreaId, A.Name As AreaName, BLD.CityId, C.NAme as CityName," +
                   "  BLD.BondType, BLD.BondNumber, BLD.GovernmentNumber, BLD.PilotNumber, BLD.Street, BLD.Address, BLD.CreatedBy, BLD.CreatedDate, BLD.UpdatedBy, BLD.UpdatedDate" +
                   " FROM property_tb BLD " +
                   "  LEFT JOIN property_tb FLT ON FLT.BuildingId = BLD.Id " +
                    " LEFT JOIN tenancyagreement_tb TA ON BLD.Id = TA.BuildingId AND TA.FlatId = FLT.Id " +
                    " LEFT JOIN LESSEELESSOR_TB LSR ON BLD.LessorId = LSR.Id " +
                    " LEFT JOIN LESSEELESSOR_TB LSe ON TA.LesseeId = LSE.Id " +
                    " LEFT JOIN City_tb AS C ON BLD.CityId = C.Id " +
                    " LEFT JOIN Area_tb AS A ON BLD.AreaId = A.Id " +
                    " WHERE (FLT.ID IN (select FlatId from tenancyagreement_tb WHERE IsCompleted=0 OR IsCancelled=0 )) " +
                     " ORDER BY BLD.PropertyType";


                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Property aProperty = new Property()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        CityId = string.IsNullOrEmpty(Convert.ToString(Reader["CityId"])) ? 0 : Convert.ToInt32(Reader["CityId"]),
                        CityName = Convert.ToString(Reader["CityName"]),
                        BuildingId = string.IsNullOrEmpty(Convert.ToString(Reader["BuildingId"])) ? 0 : Convert.ToInt32(Reader["BuildingId"]),
                        BuildingName = Convert.ToString(Reader["BuildingName"]),
                        AreaId = string.IsNullOrEmpty(Convert.ToString(Reader["AreaId"])) ? 0 : Convert.ToInt32(Reader["AreaId"]),
                        AreaName = Convert.ToString(Reader["AreaName"]),
                        LessorId = string.IsNullOrEmpty(Convert.ToString(Reader["LessorId"])) ? 0 : Convert.ToInt32(Reader["LessorId"]),
                        LessorName = Convert.ToString(Reader["LessorName"]),
                        PropertyNumber = Convert.ToString(Reader["PropertyNumber"]),
                        Name = Convert.ToString(Reader["BuildingName"]),
                        FlatNo = Convert.ToString(Reader["FlatNo"]),
                        Address = Convert.ToString(Reader["Address"]),
                        BondNumber = Convert.ToString(Reader["BondNumber"]),
                        GovernmentNumber = Convert.ToString(Reader["GovernmentNumber"]),
                        PilotNumber = Convert.ToString(Reader["PilotNumber"]),
                        Street = Convert.ToString(Reader["Street"]),
                        PropertyType = string.IsNullOrEmpty(Convert.ToString(Reader["PropertyType"])) ? 0 : Convert.ToInt32(Reader["PropertyType"]),
                        PropertyTypeName = Convert.ToString(Reader["PropertyTypeName"]),
                        FlatTypeId = string.IsNullOrEmpty(Convert.ToString(Reader["FlatTypeId"])) ? 0 : Convert.ToInt32(Reader["FlatTypeId"]),
                        FlatTypeName = Convert.ToString(Reader["FlatTypeName"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"]),
                        BondType = Convert.ToString(Reader["BondType"]),
                        AgreementNumber = Convert.ToString(Reader["AgreementNumber"]),
                        StartDate = Convert.ToString(Reader["StartDateDetail"]),
                        EndDate = Convert.ToString(Reader["EndDateDetail"]),
                        LesseeName = Convert.ToString(Reader["LesseeName"]),
                        LesseeCellNo = Convert.ToString(Reader["LesseeCell"]),
                        LesssorCellNo = Convert.ToString(Reader["LessorCell"]),
                        AgreementAmount = string.IsNullOrEmpty(Convert.ToString(Reader["TotalAmount"])) ? 0 : Convert.ToDecimal(Reader["TotalAmount"])
                    };
                    propertyList.Add(aProperty);
                }
                Connection.Close();
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propertyList;
        }




        public List<Property> GetAllOccupiedProperty()
        {
            List<Property> propertyList = new List<Property>();
            try
            {
                //Query = "SELECT * FROM Property_tb";
                Query = "SELECT P.ID, P.PropertyNumber, P.CompanyId, P.BranchId, P.AreaId, A.Name As AreaName, P.PropertyType, P.CityId, " +
                        " C.NAme as CityName,  " +
                        " CASE WHEN  P.PropertyType = 0 THEN 'Building' WHEN P.PropertyType = 1 THEN 'Vellas'  " +
                        " WHEN P.PropertyType = 2 THEN 'Flat'    ELSE 'Shop'  END 'PropertyTypeName',    " +
                        " P.NAME AS 'Name',  P.LessorId, L.NAME 'LessorName', P.BuildingId, B.Name AS 'BuildingName', P.FlatTypeId,  " +
                        " CASE " +
                            "WHEN P.FlatTypeId = 1 THEN 'Studio' " +
                            "WHEN P.FlatTypeId = 2 THEN '1 BHK' " +
                            "WHEN P.FlatTypeId = 3 THEN '2 BHK' " +
                            "WHEN P.FlatTypeId = 4 THEN '3 BHK' " +
                            "WHEN P.FlatTypeId = 5 THEN '4 BHK' " +
                            "WHEN P.FlatTypeId = 6 THEN 'Paint House' " +
                            "ELSE 'None' END 'FlatTypeName', " +
                        " P.BondType, P.BondNumber, P.GovernmentNumber, P.PilotNumber, P.Street, P.Address, P.CreatedBy, P.CreatedDate, P.UpdatedBy, P.UpdatedDate " +
                        " FROM Property_tb AS P  " +
                        " left JOIN LesseeLessor_tb AS L ON P.LessorId = L.Id  " +
                        " left JOIN Property_tb AS B ON P.BuildingId = B.Id  " +
                        " left JOIN City_tb AS C ON P.CityId = C.Id  " +
                        "  left JOIN Area_tb AS A ON P.AreaId = A.Id ORDER BY P.PropertyType";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Property aProperty = new Property()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        CityId = Convert.ToInt32(Reader["CityId"]),
                        CityName = Convert.ToString(Reader["CityName"]),
                        BuildingId = Convert.ToInt32(Reader["BuildingId"]),
                        BuildingName = Convert.ToString(Reader["BuildingName"]),
                        AreaId = Convert.ToInt32(Reader["AreaId"]),
                        AreaName = Convert.ToString(Reader["AreaName"]),
                        LessorId = Convert.ToInt32(Reader["LessorId"]),
                        LessorName = Convert.ToString(Reader["LessorName"]),
                        PropertyNumber = Convert.ToString(Reader["PropertyNumber"]),
                        Name = Convert.ToString(Reader["Name"]),
                        FlatNo = Convert.ToString(Reader["Name"]),
                         Address = Convert.ToString(Reader["Address"]),
                        BondNumber = Convert.ToString(Reader["BondNumber"]),
                        GovernmentNumber = Convert.ToString(Reader["GovernmentNumber"]),
                        PilotNumber = Convert.ToString(Reader["PilotNumber"]),
                        Street = Convert.ToString(Reader["Street"]),
                        PropertyType = Convert.ToInt32(Reader["PropertyType"]),
                        PropertyTypeName = Convert.ToString(Reader["PropertyTypeName"]),
                        FlatTypeId = string.IsNullOrEmpty(Convert.ToString(Reader["FlatTypeId"])) ? 0 : Convert.ToInt32(Reader["FlatTypeId"]),
                        FlatTypeName = Convert.ToString(Reader["FlatTypeName"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"]),
                        BondType = Convert.ToString(Reader["BondType"])
                    };
                    propertyList.Add(aProperty);
                }
                Connection.Close();
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propertyList;
        }

        public List<PropertyVM> GetAllPropertyVM()
        {
            List<PropertyVM> propertyList = new List<PropertyVM>();
            try
            {
                Query = "SELECT P.ID, P.PropertyNumber, P.CompanyId, P.BranchId, P.AreaId, A.Name As AreaName, P.PropertyType, P.CityId, C.NAme as CityName, " +
                       " CASE WHEN  P.PropertyType = 0 THEN 'Building' WHEN P.PropertyType = 1 THEN 'Vellas' WHEN P.PropertyType = 2 THEN 'Flat' " +
                         "   ELSE 'Shop' " +
                        " END 'PropertyTypeName', " +
                        " P.NAME AS 'Name',  P.LessorId, L.NAME 'LessorName', P.BuildingId, B.Name AS 'BuildingName', P.FlatTypeId, " +
                        "CASE " +
                            "WHEN P.FlatTypeId = 1 THEN 'Studio' " +
                            "WHEN P.FlatTypeId = 2 THEN '1 BHK' " +
                            "WHEN P.FlatTypeId = 3 THEN '2 BHK' " +
                            "WHEN P.FlatTypeId = 4 THEN '3 BHK' " +
                            "WHEN P.FlatTypeId = 5 THEN '4 BHK' " +
                            "WHEN P.FlatTypeId = 6 THEN 'Paint House' " +
                            "ELSE 'None' END 'FlatTypeName', P.BondType, P.BondNumber, P.GovernmentNumber, P.PilotNumber, P.Street, P.Address " +
                        "FROM Property_tb AS P " +
                        "left JOIN LesseeLessor_tb AS L ON P.LessorId = L.Id " +
                        "left JOIN Property_tb AS B ON P.BuildingId = B.Id " +
                        "left JOIN City_tb AS C ON P.CityId = C.Id " +
                        "left JOIN Area_tb AS A ON P.AreaId = A.Id ORDER BY P.PropertyType";


                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    PropertyVM aProperty = new PropertyVM()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        CityId = Convert.ToInt32(Reader["CityId"]),
                        BuildingId = Convert.ToInt32(Reader["BuildingId"]),
                        BuildingName = Convert.ToString(Reader["BuildingName"]),
                        AreaId = Convert.ToInt32(Reader["AreaId"]),
                        AreaName = Convert.ToString(Reader["AreaName"]),
                        LessorId = Convert.ToInt32(Reader["LessorId"]),
                        LessorName = Convert.ToString(Reader["LessorName"]),
                        PropertyNumber = Convert.ToString(Reader["PropertyNumber"]),
                        Name = Convert.ToString(Reader["Name"]),
                        Address = Convert.ToString(Reader["Address"]),
                        BondNumber = Convert.ToString(Reader["BondNumber"]),
                        GovernmentNumber = Convert.ToString(Reader["GovernmentNumber"]),
                        PilotNumber = Convert.ToString(Reader["PilotNumber"]),
                        Street = Convert.ToString(Reader["Street"]),
                        PropertyType = Convert.ToInt32(Reader["PropertyType"]),
                        PropertyTypeName = Convert.ToString(Reader["PropertyTypeName"]),
                        BondType = Convert.ToString(Reader["BondType"]),
                        FlatTypeId = string.IsNullOrEmpty(Convert.ToString(Reader["FlatTypeId"])) ? 0 : Convert.ToInt32(Reader["FlatTypeId"]),
                        FlatTypeName = Convert.ToString(Reader["FlatTypeName"])
                    };
                    propertyList.Add(aProperty);
                }
                Connection.Close();
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propertyList;
        }
        public List<FlatType> GetFlatType()
        {
            List<FlatType> flatTypeList = new List<FlatType>();
            try
            {
                //Query = "select 1 Id, 'Studio' FlatTypeDescription UNION ALL select 2 Id, '2 BHK' UNION ALL select 3 Id, '3 BHK' UNION ALL select 4 Id, '4 BHK' " +
                //         "  UNION ALL select 5 Id, 'Paint House' ";
                Query = "select 1 Id, 'Studio' FlatTypeDescription UNION ALL select 2 Id, '1 BHK' UNION ALL select 3 Id, '2 BHK' UNION ALL select 4 Id, '3 BHK' UNION ALL select 5 Id, '4 BHK' " +
                         "  UNION ALL select 6 Id, 'Paint House' ";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    FlatType aflatType = new FlatType()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        FlatTypeDescription = Convert.ToString(Reader["FlatTypeDescription"]),

                    };
                    flatTypeList.Add(aflatType);
                }
                Connection.Close();
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flatTypeList;
        }

        public List<PropertyType> GetAllPropertyType()
        {
            List<PropertyType> propertyTypeList = new List<PropertyType>();
            try
            {
                Query = "select 0 Id, 'Building' PropertyTypeDescription UNION ALL select 1 Id, 'Vellas' UNION ALL select 2 Id, 'Flat' UNION ALL select 3 Id, 'Shop' ";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    PropertyType aflatType = new PropertyType()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        PropertyTypeDescription = Convert.ToString(Reader["PropertyTypeDescription"]),

                    };

                    propertyTypeList.Add(aflatType);
                }
                Connection.Close();
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propertyTypeList;
        }

        public List<PropertyType> GetAllPropertyTypeNoFlat()
        {
            List<PropertyType> propertyTypeList = new List<PropertyType>();
            try
            {
                Query = "select 0 Id, 'Building' PropertyTypeDescription UNION ALL select 1 Id, 'Vellas' UNION ALL select 3 Id, 'Shop' ";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    PropertyType aflatType = new PropertyType()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        PropertyTypeDescription = Convert.ToString(Reader["PropertyTypeDescription"]),

                    };

                    propertyTypeList.Add(aflatType);
                }
                Connection.Close();
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propertyTypeList;
        }

    }
}