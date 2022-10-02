using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenantManagementSystem.Gateway;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.BLL
{
    public class CompanyManager
    {
        CompanyGateway aCompanyGateway = new CompanyGateway();
        string successMessage = string.Empty;


        public string Save(Company aCompany)
        {
            if (aCompanyGateway.Save(aCompany) > 0)
            {
                return "Company Save Successfully!!";
            }
            else
            {
                return "Failed";
            }
        }

        public string Update(Company aCompany)
        {
            try
            {
                if (aCompanyGateway.Update(aCompany) > 0)
                {
                    successMessage = "Company Save Successfully!!";
                }
                else
                {
                    successMessage = "Failed";
                }
            }
            catch (Exception ex)
            {
                successMessage = "Failed " + ex.Message;
            }
            return successMessage;
        }


        public List<Company> GetAllCompany()
        {
            CompanyGateway aCompanyGateway = new CompanyGateway();
            return aCompanyGateway.GetAllCompany();
        }

        public Company GetCompanyById(int CompanyId)
        {
            var companies = GetAllCompany();
            Company company = companies.FirstOrDefault(t => t.CompanyId == CompanyId);
            return company;
        }

    }
}