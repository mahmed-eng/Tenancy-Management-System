using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenantManagementSystem.Gateway;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.BLL
{
    public class DashboardManager
    {
        DashboardGateway aDashboardGateway = new DashboardGateway();
        PropertyGateway aPropertyGateway = new PropertyGateway();
        LesseeLessorGateway aLesseeLessorGateway = new LesseeLessorGateway();
        ChequeDetailsGateway aChequeDetailsGateway = new ChequeDetailsGateway();

        public int GetTotalFlat()
        {
            return aPropertyGateway.GetAllProperty().Where(t=> t.PropertyType == Convert.ToInt16(Property.PT.Flat)).ToList().Count();
        }

        public int GetTotalBuildingVellasShops()
        {
            return aPropertyGateway.GetAllProperty().Where(t => t.PropertyType != Convert.ToInt16(Property.PT.Flat)).ToList().Count();
        }

        public int GetTotalPendingChques()
        {
            return aChequeDetailsGateway.GetAllChequeDetails().Count();
            //return 5;
        }

        public int GetTotalRenewalProperty()
        {
            return aPropertyGateway.GetAllPropertyO().Count();
        }

        //public List<ChartVM> GetCount()
        //{
        //    return aDashboardGateway.GetCount();
        //}

        //public List<Company> GetCompany()
        //{
        //    return aDashboardGateway.GetCompany();
        //}


        //public List<Branch> GetBranch()
        //{
        //    return aDashboardGateway.GetBranch();
        //}
    }
}