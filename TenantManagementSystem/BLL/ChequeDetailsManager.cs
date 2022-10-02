using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenantManagementSystem.Gateway;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.BLL
{
    public class ChequeDetailsManager
    {
        ChequeDetailsGateway aChequeDetailsGateway = new ChequeDetailsGateway();
        string successMessage = string.Empty;

        public string Save(ChequeDetails aChequeDetails)
        {
            try
            {
                if (aChequeDetailsGateway.Save(aChequeDetails) > 0)
                {
                    successMessage = "Save Successfully!";
                }
                else
                {
                    successMessage = "Failed";
                }
            }
            catch (Exception ex)
            {
                successMessage = "Failed " + ex.Message + " " + ex.InnerException;
            }
            return successMessage;
        }

        //Update
        public string UPDATE(ChequeDetails aChequeDetails)
        {
            try
            {

                if (aChequeDetailsGateway.Update(aChequeDetails) > 0)
                {
                    successMessage = "Save Successfully!";
                }
                else
                {
                    successMessage = "Failed";
                }
            }
            catch (Exception ex)
            {
                successMessage = "Failed " + ex.Message + " " + ex.InnerException;
            }
            return successMessage;
        }
        //public string Update(ChequeDetails aChequeDetails)
        //{
        //    try
        //    {
        //        if (aChequeDetailsGateway.Update(aChequeDetails) > 0)
        //        {
        //            successMessage = "City Save Successfully!!";
        //        }
        //        else
        //        {
        //            successMessage = "Failed";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        successMessage = "Failed " + ex.Message + " " + ex.InnerException;
        //    }
        //    return successMessage;
        //}

        //Delete
        public string DELETE(ChequeDetails aChequeDetails)
        {
            try
            {
                if (aChequeDetailsGateway.Delete(aChequeDetails) > 0)
                {
                    successMessage = "Delete Successfully!";
                }
                else
                {
                    successMessage = "Failed";
                }
            }
            catch (Exception ex)
            {
                successMessage = "Failed " + ex.Message + " " + ex.InnerException;
            }
            return successMessage;
        }

        public string Update(ChequeDetails aChequeDetails)
        {
            try
            {
                if (aChequeDetailsGateway.Update(aChequeDetails) > 0)
                {
                    successMessage = "Details Save Successfully!!";
                }
                else
                {
                    successMessage = "Failed";
                }
            }
            catch (Exception ex)
            {
                successMessage = "Failed " + ex.Message + " " + ex.InnerException;
            }
            return successMessage;
        }


        //View
        //public string DELETE(Property aProperty)
        //{
        //    if (aPropertyGateway.Delete(aProperty) > 0)
        //    {
        //        return "Delete Successfully!";
        //    }
        //    else
        //    {
        //        return "Failed";
        //    }
        //}



        public List<ChequeDetails> GetAllChequeDetails()
        {
            return aChequeDetailsGateway.GetAllChequeDetails();
        }

        public List<ChequeDetails> GetAllChequeDetailsView()
        {
            return aChequeDetailsGateway.GetAllChequeDetailsView();
        }
        public ChequeDetails GetAllChequeDetailsById(int ChequeDetailsId)
        {
            var chequeDetailsList = GetAllChequeDetails();
            ChequeDetails chequeDetails = chequeDetailsList.FirstOrDefault(ChequeDetails => ChequeDetails.Id == ChequeDetailsId);
            return chequeDetails;
        }

    }
}