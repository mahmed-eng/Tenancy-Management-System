using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenantManagementSystem.Gateway;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.BLL
{
    public class AreaManager
    {
        AreaGateway aAreaGateway = new AreaGateway();
        string successMessage = string.Empty;

        public string Save(Area aArea)
        {
            try
            {
                if (aAreaGateway.Save(aArea) > 0)
                {
                    successMessage = "Save Successfully!!";
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

        public string Update(Area aArea)
        {
            try
            {
                if (aAreaGateway.Update(aArea) > 0)
                {
                    successMessage = "Save Successfully!!";
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


        public List<Area> GetAllArea()
        {
            return aAreaGateway.GetAllArea();
        }

        public Area GetAreaById(int AreaId)
        {
            var areas = GetAllArea();
            Area area = areas.FirstOrDefault(t => t.Id == AreaId);
            return area;
        }

    }
}