using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TenantManagementSystem.BLL;

namespace TenantManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        DashboardManager aDashboardManager = new DashboardManager();
        PropertyManager aPropertyManager = new PropertyManager();
        TenancyAgreementManager aTenancyAgreementManager = new TenancyAgreementManager();
        ChequeDetailsManager aChequeDetailsManager = new ChequeDetailsManager();

        public ActionResult Dashboard()
        {
            //ViewBag.Flat = aDashboardManager.GetTotalFlat();
            //ViewBag.BuildingVellasShops = aDashboardManager.GetTotalBuildingVellasShops();
            //ViewBag.RenewalProperty = aDashboardManager.GetTotalRenewalProperty();
            //ViewBag.PendingCheques = aDashboardManager.GetTotalPendingChques();

            try
            {
                ViewBag.PendingCheques = aChequeDetailsManager.GetAllChequeDetailsView().Where(t => t.IsCashed == false).Count();
            }
            catch (Exception)
            {
                ViewBag.PendingCheques = 0;
            }
            //ViewBag.PendingCheques = aDashboardManager.GetTotalPendingChques();

            try
            {
                ViewBag.RenewalProperty = aTenancyAgreementManager.GetAllTenancyAgreementView().Count();
            }
            catch (Exception)
            {
                ViewBag.RenewalProperty = 0;
            }

            try
            {
                ViewBag.UOP = aPropertyManager.GetAllPropertyUO().Where(l => l.BuildingId != 0).Count();
            }
            catch (Exception)
            {
                ViewBag.UOP = 0;
            }

            try
            {
                ViewBag.OP = aPropertyManager.GetAllPropertyO().Count();
            }
            catch (Exception)
            {
                ViewBag.OP = 0;
            }
            //ViewBag.Chart = aDashboardManager.GetCount();
            return View();
        }
    }
}