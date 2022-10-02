using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenantManagementSystem.Gateway;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.BLL
{
    public class TenancyAgreementManager
    {
        TenancyAgreementGateway aTenancyAgreementGateway = new TenancyAgreementGateway();
        string successMessage = string.Empty;

        public string Save(TenancyAgreement aTenancyAgreement)
        {
            try
            {
                if (aTenancyAgreementGateway.Save(aTenancyAgreement) > 0)
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
        public string UPDATE(TenancyAgreement aTenancyAgreement)
        {
            try
            {
                if (aTenancyAgreementGateway.Update(aTenancyAgreement) > 0)
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


        //Delete
        public string DELETE(TenancyAgreement aTenancyAgreement)
        {
            try
            {
                if (aTenancyAgreementGateway.Delete(aTenancyAgreement) > 0)
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

        public string Update(TenancyAgreement aTenancyAgreement)
        {
            try
            {
                if (aTenancyAgreementGateway.Update(aTenancyAgreement) > 0)
                {
                    successMessage = "Agreement Save Successfully!!";
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



        public List<TenancyAgreement> GetAllTenancyAgreement()
        {
            try
            {
                return aTenancyAgreementGateway.GetAllTenancyAgreement();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<TenancyAgreement> GetAllTenancyAgreementView()
        {
            return aTenancyAgreementGateway.GetAllTenancyAgreementView();
        }
        public TenancyAgreement GetAllTenancyAgreementById(int TenancyAgreementId)
        {
            try
            {
                var tenancyAgreementList = GetAllTenancyAgreement();
                TenancyAgreement tenancyAgreement = tenancyAgreementList.FirstOrDefault(t => t.Id == TenancyAgreementId);
                return tenancyAgreement;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}