using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Gateway
{
    public class TenancyAgreementGateway : Gateway
    {
        public int Save(TenancyAgreement aTenancyAgreement)
        {
            Query = "INSERT INTO TenancyAgreement_tb (AgreementNumber, LessorId, LesseeId, BuildingId, FlatId, StartDate, EndDate, RentDurationinDays, RentDurationinMonths, MonthlyAmount,  TotalAmount, CreatedBy, CreatedDate, IsStarted, IsCompleted, IsCancelled) " +
                    "VALUES(@agreementnumber, @lessorid, @lesseeid, @buildingid, @flatid, @startdate, @enddate, @rentdurationindays, @rentdurationinmonths, @monthlyamount, @totalamount, @createdBy, @createdDate, @isstarted, @iscompleted, @iscancelled)";
            Command = new MySqlCommand(Query, Connection);
            Command.Parameters.Clear();
            //Command.Parameters.AddWithValue("id", aCompany.CompanyId);
            //Command.Parameters.AddWithValue("id", aTenancyAgreement.Id);
            Command.Parameters.AddWithValue("agreementnumber", aTenancyAgreement.AgreementNumber);
            Command.Parameters.AddWithValue("lessorid", aTenancyAgreement.LessorId);
            Command.Parameters.AddWithValue("lesseeid", aTenancyAgreement.LesseeId);
            Command.Parameters.AddWithValue("buildingid", aTenancyAgreement.BuildingId);
            Command.Parameters.AddWithValue("flatid", aTenancyAgreement.FlatId);
            Command.Parameters.AddWithValue("startdate", aTenancyAgreement.StartDate);
            Command.Parameters.AddWithValue("enddate", aTenancyAgreement.EndDate);
            Command.Parameters.AddWithValue("rentdurationindays", aTenancyAgreement.RentDurationinDays);
            Command.Parameters.AddWithValue("rentdurationinmonths", aTenancyAgreement.RentDurationinMonths);
            Command.Parameters.AddWithValue("monthlyamount", aTenancyAgreement.MonthlyAmount);
            Command.Parameters.AddWithValue("totalamount", aTenancyAgreement.TotalAmount);
            Command.Parameters.AddWithValue("createdBy", aTenancyAgreement.CreatedBy);
            Command.Parameters.AddWithValue("createdDate", aTenancyAgreement.CreatedDate);
            Command.Parameters.AddWithValue("isstarted", aTenancyAgreement.IsStarted);
            Command.Parameters.AddWithValue("iscompleted", aTenancyAgreement.IsCompleted);
            Command.Parameters.AddWithValue("iscancelled", aTenancyAgreement.IsCancelled);

            //Command.Parameters.AddWithValue("bondtype", aProperty.BondType);


            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        //Delete
        public int Delete(TenancyAgreement aTenancyAgreement)
        {
            Query = "DELETE FROM Property WHERE Id = @id";

            Command = new MySqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("id", aTenancyAgreement.Id);
            Command.Parameters.AddWithValue("agreementnumber", aTenancyAgreement.AgreementNumber);
            Command.Parameters.AddWithValue("lessorid", aTenancyAgreement.LessorId);
            Command.Parameters.AddWithValue("lesseeid", aTenancyAgreement.LesseeId);
            Command.Parameters.AddWithValue("buildingid", aTenancyAgreement.BuildingId);
            Command.Parameters.AddWithValue("flatid", aTenancyAgreement.FlatId);
            Command.Parameters.AddWithValue("startdate", aTenancyAgreement.StartDate);
            Command.Parameters.AddWithValue("enddate", aTenancyAgreement.EndDate);
            Command.Parameters.AddWithValue("rentdurationindays", aTenancyAgreement.RentDurationinDays);
            Command.Parameters.AddWithValue("rentdurationinmonths", aTenancyAgreement.RentDurationinMonths);
            Command.Parameters.AddWithValue("monthlyamount", aTenancyAgreement.MonthlyAmount);
            Command.Parameters.AddWithValue("totalamount", aTenancyAgreement.TotalAmount);


            //Command.Parameters.AddWithValue("peneficiary", aProperty.Peneficiary);
            //Command.Parameters.AddWithValue("Profession", aProperty.Profession);
            //Command.Parameters.AddWithValue("address", aProperty.Address);
            //Command.Parameters.AddWithValue("fax", aProperty.Fax);
            //Command.Parameters.AddWithValue("phone", aProperty.Phone);
            //Command.Parameters.AddWithValue("Pobox", aProperty.POBox);
            //Command.Parameters.AddWithValue("email", aProperty.Email);
            //Command.Parameters.AddWithValue("nopr", aProperty.NOPR);
            Command.Parameters.AddWithValue("createdBy", string.IsNullOrEmpty(Convert.ToString(aTenancyAgreement.CreatedBy)) ? 0 : Convert.ToInt32(aTenancyAgreement.CreatedBy));
            Command.Parameters.AddWithValue("createdDate", string.IsNullOrEmpty(Convert.ToString(aTenancyAgreement.CreatedDate)) ? 0 : Convert.ToInt32(aTenancyAgreement.CreatedDate));


            Command.Parameters.AddWithValue("updatedBy", string.IsNullOrEmpty(Convert.ToString(aTenancyAgreement.UpdatedBy)) ? 0 : Convert.ToInt32(aTenancyAgreement.UpdatedBy));
            Command.Parameters.AddWithValue("UpdatedDate", string.IsNullOrEmpty(Convert.ToString(aTenancyAgreement.UpdatedDate)) ? DateTime.Now : Convert.ToDateTime(aTenancyAgreement.UpdatedDate));
            //Command.Parameters.AddWithValue("recordtype", aTenancyAgreement.BondType);


            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public int Update(TenancyAgreement aTenancyAgreement)
        {
            int rowCount = 0;

            try
            {

                Query = "UPDATE TenancyAgreement_tb SET AgreementNumber=@agreementnumber, LessorId = @lessorid, LesseeId = @lesseeid, BuildingId=@buildingid," +
                    " FlatId=@flatid, StartDate = @startdate, EndDate = @enddate, RentDurationinDays = @rentdurationindays, RentDurationinMonths = @rentdurationinmonths, " +
               "MonthlyAmount = @monthlyamount, TotalAmount = @totalamount, UpdatedBy = @updatedBy, UpdatedDate = @updatedDate, IsStarted = @isstarted," +
               " IsCompleted = @iscompleted, IsCancelled = @iscancelled WHERE Id = @id";

                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.AddWithValue("id", aTenancyAgreement.Id);
                Command.Parameters.AddWithValue("agreementnumber", aTenancyAgreement.AgreementNumber);
                Command.Parameters.AddWithValue("lessorid", aTenancyAgreement.LessorId);
                Command.Parameters.AddWithValue("lesseeid", aTenancyAgreement.LesseeId);
                Command.Parameters.AddWithValue("buildingid", aTenancyAgreement.BuildingId);
                Command.Parameters.AddWithValue("flatid", aTenancyAgreement.FlatId);
                Command.Parameters.AddWithValue("startdate", aTenancyAgreement.StartDate);
                Command.Parameters.AddWithValue("enddate", aTenancyAgreement.EndDate);
                Command.Parameters.AddWithValue("rentdurationindays", aTenancyAgreement.RentDurationinDays);
                Command.Parameters.AddWithValue("rentdurationinmonths", aTenancyAgreement.RentDurationinMonths);
                Command.Parameters.AddWithValue("monthlyamount", aTenancyAgreement.MonthlyAmount);
                Command.Parameters.AddWithValue("totalamount", aTenancyAgreement.TotalAmount);
                Command.Parameters.AddWithValue("isstarted", aTenancyAgreement.IsStarted);
                Command.Parameters.AddWithValue("iscompleted", aTenancyAgreement.IsCompleted);
                Command.Parameters.AddWithValue("iscancelled", aTenancyAgreement.IsCancelled);
                Command.Parameters.AddWithValue("updatedBy", aTenancyAgreement.UpdatedBy);
                Command.Parameters.AddWithValue("updatedDate", aTenancyAgreement.UpdatedDate);


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


        public List<TenancyAgreement> GetAllTenancyAgreement()
        {
            List<TenancyAgreement> tenancyAgreementList = new List<TenancyAgreement>();
            try
            {
                Query = " SELECT TA.Id, TA.AgreementNumber, TA.LessorId, LSR.Name LessorName,  TA.LesseeId, LSE.Name LesseeName, " +
                        " TA.BuildingId, BLD.Name BuildingName, TA.FlatId, FLT.Name FlatNo, DATE_FORMAT(TA.StartDate, '%d-%b-%Y') StartDateDetail, " +
                        " DATE_FORMAT(TA.EndDate, '%d-%b-%Y') EndDateDetail, TA.StartDate, TA.EndDate, " +
                        " TA.RentDurationinDays, TA.RentDurationinMonths, TA.MonthlyAmount, TA.TotalAmount, TA.IsStarted, TA.IsCompleted, TA.IsCancelled, FLT.FlatTypeId, " +
                        " CASE WHEN FLT.FlatTypeId = 1 THEN 'Studio' WHEN FLT.FlatTypeId = 2 THEN '1 BHK' WHEN FLT.FlatTypeId = 3 THEN '2 BHK'  " +
                        " WHEN FLT.FlatTypeId = 4 THEN '3 BHK' WHEN FLT.FlatTypeId = 5 THEN '4 BHK' WHEN FLT.FlatTypeId = 6 THEN 'Paint House' ELSE 'None' END 'FlatType', " +
                        " TA.CreatedBy, TA.CreatedDate, TA.UpdatedBy, TA.UpdatedDate " +
                        " FROM tenancyagreement_tb TA " +
                        " LEFT JOIN LESSEELESSOR_TB LSR ON TA.LessorId = LSR.Id " +
                        " LEFT JOIN LESSEELESSOR_TB LSe ON TA.LesseeId = LSE.Id " +
                        " LEFT JOIN property_tb BLD ON TA.BuildingId = BLD.Id " +
                        " LEFT JOIN property_tb FLT ON TA.FlatId = FLT.Id ";

                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    TenancyAgreement aTenancyAgreement = new TenancyAgreement()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        AgreementNumber = Convert.ToString(Reader["AgreementNumber"]),
                        LessorId = Convert.ToInt32(Reader["LessorId"]),
                        LessorName = Convert.ToString(Reader["LessorName"]),
                        LesseeId = string.IsNullOrEmpty(Convert.ToString(Reader["LesseeId"])) ? 0 : Convert.ToInt32(Reader["LesseeId"]),
                        LesseeName = Convert.ToString(Reader["LesseeName"]),
                        BuildingId = Convert.ToInt32(Reader["BuildingId"]),
                        BuildingName = Convert.ToString(Reader["BuildingName"]),
                        FlatId = Convert.ToInt32(Reader["FlatId"]),
                        FlatNo = Convert.ToString(Reader["FlatNo"]),
                        FlatTypeId = string.IsNullOrEmpty(Convert.ToString(Reader["FlatTypeId"])) ? 0 : Convert.ToInt32(Reader["FlatTypeId"]),
                        FlatType = Convert.ToString(Reader["FlatType"]),
                        StartDate = string.IsNullOrEmpty(Convert.ToString(Reader["StartDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["StartDate"]),
                        StartDateDetail = Convert.ToString(Reader["StartDateDetail"]),
                        EndDateDetail = Convert.ToString(Reader["EndDateDetail"]),
                        EndDate = string.IsNullOrEmpty(Convert.ToString(Reader["EndDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["EndDate"]),
                        RentDurationinDays = Convert.ToInt32(Reader["RentDurationinDays"]),
                        RentDurationinMonths = Convert.ToInt32(Reader["RentDurationinMonths"]),
                        MonthlyAmount = Convert.ToDecimal(Reader["MonthlyAmount"]),
                        TotalAmount = Convert.ToDecimal(Reader["TotalAmount"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"]),
                        IsStarted = string.IsNullOrEmpty(Convert.ToString(Reader["IsStarted"])) ? false : Convert.ToBoolean(Reader["IsStarted"]),
                        IsCompleted = string.IsNullOrEmpty(Convert.ToString(Reader["IsCompleted"])) ? false : Convert.ToBoolean(Reader["IsCompleted"]),
                        IsCancelled = string.IsNullOrEmpty(Convert.ToString(Reader["IsCancelled"])) ? false : Convert.ToBoolean(Reader["IsCancelled"])

                    };
                    tenancyAgreementList.Add(aTenancyAgreement);
                }
                Connection.Close();
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tenancyAgreementList;
        }

        public List<TenancyAgreement> GetAllTenancyAgreementView()
        {
            List<TenancyAgreement> tenancyAgreementList = new List<TenancyAgreement>();
            try
            {
                Query = " select * from tenancyagreementview ";

                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    TenancyAgreement aTenancyAgreement = new TenancyAgreement()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        AgreementNumber = Convert.ToString(Reader["AgreementNumber"]),
                        LessorId = Convert.ToInt32(Reader["LessorId"]),
                        LessorName = Convert.ToString(Reader["LessorName"]),
                        LesseeId = string.IsNullOrEmpty(Convert.ToString(Reader["LesseeId"])) ? 0 : Convert.ToInt32(Reader["LesseeId"]),
                        LesseeName = Convert.ToString(Reader["LesseeName"]),
                        BuildingId = Convert.ToInt32(Reader["BuildingId"]),
                        BuildingName = Convert.ToString(Reader["BuildingName"]),
                        FlatId = Convert.ToInt32(Reader["FlatId"]),
                        FlatNo = Convert.ToString(Reader["FlatNo"]),
                        FlatTypeId = string.IsNullOrEmpty(Convert.ToString(Reader["FlatTypeId"])) ? 0 : Convert.ToInt32(Reader["FlatTypeId"]),
                        FlatType = Convert.ToString(Reader["FlatType"]),
                        StartDate = string.IsNullOrEmpty(Convert.ToString(Reader["StartDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["StartDate"]),
                        StartDateDetail = Convert.ToString(Reader["StartDateDetail"]),
                        EndDateDetail = Convert.ToString(Reader["EndDateDetail"]),
                        EndDate = string.IsNullOrEmpty(Convert.ToString(Reader["EndDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["EndDate"]),
                        RentDurationinDays = Convert.ToInt32(Reader["RentDurationinDays"]),
                        RentDurationinMonths = Convert.ToInt32(Reader["RentDurationinMonths"]),
                        MonthlyAmount = Convert.ToDecimal(Reader["MonthlyAmount"]),
                        TotalAmount = Convert.ToDecimal(Reader["TotalAmount"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"]),
                        IsStarted = string.IsNullOrEmpty(Convert.ToString(Reader["IsStarted"])) ? false : Convert.ToBoolean(Reader["IsStarted"]),
                        IsCompleted = string.IsNullOrEmpty(Convert.ToString(Reader["IsCompleted"])) ? false : Convert.ToBoolean(Reader["IsCompleted"]),
                        IsCancelled = string.IsNullOrEmpty(Convert.ToString(Reader["IsCancelled"])) ? false : Convert.ToBoolean(Reader["IsCancelled"])

                    };
                    tenancyAgreementList.Add(aTenancyAgreement);
                }
                Connection.Close();
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tenancyAgreementList;
        }
    }
}