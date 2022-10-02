using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenantManagementSystem.Gateway;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.BLL
{
    public class AdminManager
    {
        AdminGateway adminGateway = new AdminGateway();

        public string Save(Admin admin)
        {
            if (adminGateway.Save(admin) > 0)
            {
                return "Admin Registration Successfully Done";
            }
            else
            {
                return "Failed";
            }
        }
        public string SaveChangePassword(AdminChangePassowrd admin)
        {
            if (adminGateway.SaveChangePassword(admin) > 0)
            {
                return "Password Change Successfully!!";
            }
            else
            {
                return "Failed";
            }
        }

        public List<Admin> GetAdmin()
        {
            return adminGateway.GetAdmin();
        }
    }
}