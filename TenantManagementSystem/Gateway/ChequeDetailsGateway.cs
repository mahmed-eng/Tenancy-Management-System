using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Gateway
{
    public class ChequeDetailsGateway : Gateway
    {
        public int Save(ChequeDetails aChequeDetails)
        {
            Query = "INSERT INTO ChequeDetails (ChequeNumber, TenantAgreementNumber, TenantAgreementId, BranchId, CompanyId, Amount, IsCashed, PaymentFromCash, ChequeDate, CreatedBy, CreatedDate) " +
                    "VALUES(@chequenumber, @tenantagreementnumber, @tenantagreementid, @branchid, @companyid, @amount, @iscashed, @paymentfromcash, @chequedate, @createdBy, @createdDate)";
            Command = new MySqlCommand(Query, Connection);
            Command.Parameters.Clear();
            //Command.Parameters.AddWithValue("id", aCompany.CompanyId);
            //Command.Parameters.AddWithValue("id", aTenancyAgreement.Id);
            Command.Parameters.AddWithValue("chequenumber", aChequeDetails.ChequeNumber);
            Command.Parameters.AddWithValue("tenantagreementnumber", aChequeDetails.TenantAgreementNumber);
            Command.Parameters.AddWithValue("tenantagreementid", aChequeDetails.TenantAgreementId);
            Command.Parameters.AddWithValue("amount", aChequeDetails.Amount);
            Command.Parameters.AddWithValue("iscashed", aChequeDetails.IsCashed);
            Command.Parameters.AddWithValue("paymentfromcash", aChequeDetails.PaymentFromCash);
            Command.Parameters.AddWithValue("chequedate", aChequeDetails.ChequeDate);
            Command.Parameters.AddWithValue("createdby", aChequeDetails.CreatedBy);
            Command.Parameters.AddWithValue("createddate", aChequeDetails.CreatedDate);
            Command.Parameters.AddWithValue("branchid", aChequeDetails.BranchId);
            Command.Parameters.AddWithValue("companyid", aChequeDetails.CompanyId);


            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        //Delete
        public int Delete(ChequeDetails aChequeDetails)
        {
            Query = "DELETE FROM Property WHERE Id = @id";

            Command = new MySqlCommand(Query, Connection);
            Command.Parameters.Clear();
            //Command.Parameters.AddWithValue("id", aTenancyAgreement.Id);
            //Command.Parameters.AddWithValue("agreementnumber", aTenancyAgreement.AgreementNumber);
            //Command.Parameters.AddWithValue("lessorid", aTenancyAgreement.LessorId);
            //Command.Parameters.AddWithValue("buildingid", aTenancyAgreement.BuildingId);
            //Command.Parameters.AddWithValue("flatid", aTenancyAgreement.FlatId);
            //Command.Parameters.AddWithValue("startdate", aTenancyAgreement.StartDate);
            //Command.Parameters.AddWithValue("enddate", aTenancyAgreement.EndDate);
            //Command.Parameters.AddWithValue("rentdurationindays", aTenancyAgreement.RentDurationinDays);
            //Command.Parameters.AddWithValue("rentdurationinmonths", aTenancyAgreement.RentDurationinMonths);
            //Command.Parameters.AddWithValue("monthlyamount", aTenancyAgreement.MonthlyAmount);
            //Command.Parameters.AddWithValue("totalamount", aTenancyAgreement.TotalAmount);


            //Command.Parameters.AddWithValue("createdBy", string.IsNullOrEmpty(Convert.ToString(aTenancyAgreement.CreatedBy)) ? 0 : Convert.ToInt32(aTenancyAgreement.CreatedBy));
            //Command.Parameters.AddWithValue("createdDate", string.IsNullOrEmpty(Convert.ToString(aTenancyAgreement.CreatedDate)) ? 0 : Convert.ToInt32(aTenancyAgreement.CreatedDate));


            //Command.Parameters.AddWithValue("updatedBy", string.IsNullOrEmpty(Convert.ToString(aTenancyAgreement.UpdatedBy)) ? 0 : Convert.ToInt32(aTenancyAgreement.UpdatedBy));
            //Command.Parameters.AddWithValue("UpdatedDate", string.IsNullOrEmpty(Convert.ToString(aTenancyAgreement.UpdatedDate)) ? DateTime.Now : Convert.ToDateTime(aTenancyAgreement.UpdatedDate));


            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public int Update(ChequeDetails aChequeDetails)
        {
            int rowCount = 0;

            try
            {

                Query = "UPDATE ChequeDetails SET ChequeNumber=@chequenumber, TenantAgreementNumber = @tenantagreementnumber, TenantAgreementId = @tenantagreementid, " +
               " Amount = @amount, IsCashed = @iscashed, PaymentFromCash = @paymentfromcash, ChequeDate = @chequedate, " +
               " UpdatedBy = @updatedBy, UpdatedDate = @updatedDate WHERE Id = @id";

                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.AddWithValue("id", aChequeDetails.Id);
                Command.Parameters.AddWithValue("chequenumber", aChequeDetails.ChequeNumber);
                Command.Parameters.AddWithValue("tenantagreementnumber", aChequeDetails.TenantAgreementNumber);
                Command.Parameters.AddWithValue("tenantagreementid", aChequeDetails.TenantAgreementId);
                Command.Parameters.AddWithValue("amount", aChequeDetails.Amount);
                Command.Parameters.AddWithValue("iscashed", aChequeDetails.IsCashed);
                Command.Parameters.AddWithValue("paymentfromcash", aChequeDetails.PaymentFromCash);
                Command.Parameters.AddWithValue("chequedate", aChequeDetails.ChequeDate);
                //Command.Parameters.AddWithValue("createdby", aChequeDetails.CreatedBy);
                //Command.Parameters.AddWithValue("createddate", aChequeDetails.CreatedDate);
                Command.Parameters.AddWithValue("updatedby", aChequeDetails.UpdatedBy);
                Command.Parameters.AddWithValue("updateddate", aChequeDetails.UpdatedDate);
                //Command.Parameters.AddWithValue("branchid", aChequeDetails.BranchId);
                //Command.Parameters.AddWithValue("companyid", aChequeDetails.CompanyId);


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


        public List<ChequeDetails> GetAllChequeDetails()
        {
            List<ChequeDetails> chequeDetailsList = new List<ChequeDetails>();
            try
            {
                Query = "SELECT C.Id, C.ChequeNumber, c.TenantAgreementNumber, C.TenantAgreementId, C.BranchId, C.CompanyId, " +
                    "   C.Amount, C.CreatedBy, C.CreatedDate, C.UpdatedBy, C.UpdatedDate, C.IsCashed, C.ChequeDate, C.PaymentfromCash, " +
                    "   DATE_FORMAT(C.CreatedDate, '%d-%b-%Y') CreatedDateDetail, DATE_FORMAT(C.ChequeDate, '%d-%b-%Y') ChequeDateDetail " +
                    " FROM chequedetails C";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    ChequeDetails aChequeDetails = new ChequeDetails()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        ChequeNumber = Convert.ToString(Reader["ChequeNumber"]),
                        TenantAgreementNumber = Convert.ToString(Reader["TenantAgreementNumber"]),
                        TenantAgreementId = Convert.ToInt32(Reader["TenantAgreementId"]),
                        BranchId = Convert.ToInt32(Reader["BranchId"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                        Amount = Convert.ToDecimal(Reader["Amount"]),
                        //IsCashed = string.IsNullOrEmpty(Convert.ToString(Reader["IsCashed"])) ? false : Convert.ToBoolean(Reader["IsCashed"]),
                        ChequeDate = string.IsNullOrEmpty(Convert.ToString(Reader["ChequeDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["ChequeDate"]).Date,
                        ChequeDateDetail = Convert.ToString(Reader["ChequeDateDetail"]),
                        CreatedDateDetail = Convert.ToString(Reader["CreatedDateDetail"]),
                        //EndDateDetail = Convert.ToString(Reader["EndDateDetail"]),
                        //FlatId = Convert.ToInt32(Reader["FlatId"]),
                        //StartDate = string.IsNullOrEmpty(Convert.ToString(Reader["StartDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["StartDate"]),
                        //EndDate = string.IsNullOrEmpty(Convert.ToString(Reader["EndDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["EndDate"]),
                        //RentDurationinDays = Convert.ToInt32(Reader["RentDurationinDays"]),
                        //RentDurationinMonths = Convert.ToInt32(Reader["RentDurationinMonths"]),
                        //MonthlyAmount = Convert.ToDecimal(Reader["MonthlyAmount"]),
                        //TotalAmount = Convert.ToDecimal(Reader["TotalAmount"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]).Date,
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"]),
                        IsCashed = string.IsNullOrEmpty(Convert.ToString(Reader["IsCashed"])) ? false : Convert.ToBoolean(Reader["IsCashed"]),
                        //PaymentFromCash = string.IsNullOrEmpty(Convert.ToString(Reader["PaymentFromCash"])) ? 0 : Convert.ToInt32(Reader["PaymentFromCash"])
                        PaymentFromCash = string.IsNullOrEmpty(Convert.ToString(Reader["PaymentFromCash"])) ? false : Convert.ToBoolean(Reader["PaymentFromCash"]),

                        ////IsCompleted = string.IsNullOrEmpty(Convert.ToString(Reader["IsCompleted"])) ? false : Convert.ToBoolean(Reader["IsCompleted"]),
                        ////IsCancelled = string.IsNullOrEmpty(Convert.ToString(Reader["IsCancelled"])) ? false : Convert.ToBoolean(Reader["IsCancelled"])




                    };
                    chequeDetailsList.Add(aChequeDetails);
                }
                Connection.Close();
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return chequeDetailsList;
        }

        public List<ChequeDetails> GetAllChequeDetailsView()
        {
            List<ChequeDetails> chequeDetailsList = new List<ChequeDetails>();
            try
            {
                Query = "SELECT  * FROM ChequeDetailsView CDV ";
                    //"WHERE CDV.LessorId = 7 AND CDV.IsCashed = 0 AND CDV.PaymentFromCash = 0  " +
                    //"AND(CDV.ChequeDate BETWEEN '2022-09-17 00:00:00.000' AND '2022-09-17 00:00:00.000')";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    ChequeDetails aChequeDetails = new ChequeDetails()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        ChequeNumber = Convert.ToString(Reader["ChequeNumber"]),
                        TenantAgreementNumber = Convert.ToString(Reader["TenantAgreementNumber"]),
                        TenantAgreementId = Convert.ToInt32(Reader["TenantAgreementId"]),
                        BranchId = Convert.ToInt32(Reader["BranchId"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                        BuildingId = string.IsNullOrEmpty(Convert.ToString(Reader["BuildingId"])) ? 0 : Convert.ToInt32(Reader["BuildingId"]),
                        Amount = Convert.ToDecimal(Reader["Amount"]),
                        //IsCashed = string.IsNullOrEmpty(Convert.ToString(Reader["IsCashed"])) ? false : Convert.ToBoolean(Reader["IsCashed"]),
                        ChequeDate = string.IsNullOrEmpty(Convert.ToString(Reader["ChequeDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["ChequeDate"]).Date,
                        ChequeDateDetail = Convert.ToString(Reader["ChequeDateDetail"]),
                        CreatedDateDetail = Convert.ToString(Reader["CreatedDateDetail"]),
                        LessorId = string.IsNullOrEmpty(Convert.ToString(Reader["LessorId"])) ? 0 : Convert.ToInt32(Reader["LessorId"]),
                        LessorName = Convert.ToString(Reader["LessorName"]),
                        LesseeId = string.IsNullOrEmpty(Convert.ToString(Reader["LesseeId"])) ? 0 : Convert.ToInt32(Reader["LesseeId"]),
                        LesseeName = Convert.ToString(Reader["LesseeName"]),
                        //RentDurationinDays = Convert.ToInt32(Reader["RentDurationinDays"]),
                        //RentDurationinMonths = Convert.ToInt32(Reader["RentDurationinMonths"]),
                        //MonthlyAmount = Convert.ToDecimal(Reader["MonthlyAmount"]),
                        //TotalAmount = Convert.ToDecimal(Reader["TotalAmount"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]).Date,
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"]),
                        IsCashed = string.IsNullOrEmpty(Convert.ToString(Reader["IsCashed"])) ? false : Convert.ToBoolean(Reader["IsCashed"]),
                        //PaymentFromCash = string.IsNullOrEmpty(Convert.ToString(Reader["PaymentFromCash"])) ? 0 : Convert.ToInt32(Reader["PaymentFromCash"])
                        PaymentFromCash = string.IsNullOrEmpty(Convert.ToString(Reader["PaymentFromCash"])) ? false : Convert.ToBoolean(Reader["PaymentFromCash"]),

                        ////IsCompleted = string.IsNullOrEmpty(Convert.ToString(Reader["IsCompleted"])) ? false : Convert.ToBoolean(Reader["IsCompleted"]),
                        ////IsCancelled = string.IsNullOrEmpty(Convert.ToString(Reader["IsCancelled"])) ? false : Convert.ToBoolean(Reader["IsCancelled"])




                    };
                    chequeDetailsList.Add(aChequeDetails);
                }
                Connection.Close();
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return chequeDetailsList;
        }
    }
}