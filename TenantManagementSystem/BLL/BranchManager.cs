using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenantManagementSystem.Gateway;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.BLL
{
    public class BranchManager
    {
        BranchGateway aBranchGateway = new BranchGateway();
        string successMessage = string.Empty;

        public string Save(Branch aBranch)
        {
            try
            {
                if (aBranchGateway.Save(aBranch) > 0)
                {
                    successMessage = "Branch Save Successfully!!";
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

        public string Update(Branch aBranch)
        {
            try
            {
                if (aBranchGateway.Update(aBranch) > 0)
                {
                    successMessage = "Branch Save Successfully!!";
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

        public List<Branch> GetAllBranch()
        {
            return aBranchGateway.GetAllBranch();
        }

        public Branch GetBranchById(int BranchId)
        {
            var branches = GetAllBranch();
            Branch branch = branches.FirstOrDefault(t => t.BranchId == BranchId);
            return branch;
        }
    }
}