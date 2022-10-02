using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TenantManagementSystem.BLL;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Controllers
{
    public class AreaController : Controller
    {
        CompanyManager aCompanyManager = new CompanyManager();
        BranchManager aBranchManager = new BranchManager();
        AreaManager aAreaManager = new AreaManager();
        CityManager aCityManager = new CityManager();

        [HttpGet]
        public ActionResult SaveArea()
        {

            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();
            ViewBag.City = aCityManager.GetAllCity();
            Area aArea = new Area();

            return View(aArea);
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpPost]
        public ActionResult SaveArea(Area aArea)
        {
            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.City = aCityManager.GetAllCity();
            ViewBag.Branch = aBranchManager.GetAllBranch();
            aArea.CreatedBy = Convert.ToInt16(Session["Id"]);
            aArea.CreatedDate = DateTime.Now;
            aArea.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aArea.BranchId = Convert.ToInt16(Session["BranchId"]);
            ViewBag.Message = aAreaManager.Save(aArea);
            return View();
        }

        //----------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Area aArea = aAreaManager.GetAreaById(id);
            ViewBag.City = aCityManager.GetAllCity();
            return View("Edit", aArea);
        }

        [HttpPost]
        public ActionResult Edit(int id, Area aArea)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Area = aAreaManager.GetAllArea();
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();
            ViewBag.City = aCityManager.GetAllCity();
            aArea.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aArea.UpdatedDate = DateTime.Now;
            ViewBag.Message = aAreaManager.Update(aArea);
            return View(aArea);
        }
        //------------------------------------------------

        [HttpGet]
        //public JsonResult IsEmailExist(Area aArea)
        //{
        //    List<Area> Area = aAreaManager.GetAllArea();
        //    bool isExist = Area.FirstOrDefault(t => t.Area.ToLowerInvariant().Equals(aArea.Area.ToLower())) != null;
        //    return Json(!isExist, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetAreaById(Area Area)
        {
            var Companies = aAreaManager.GetAllArea();
            var AreaList = Companies.Where(t => t.Id == Area.Id).ToList();
            return Json(AreaList);
        }

        [HttpGet]
        public ActionResult ViewArea()
        {
            List<Area> Area = aAreaManager.GetAllArea();
            ViewBag.Area = aAreaManager.GetAllArea();
            ViewBag.City = aCityManager.GetAllCity();
            return View(Area);
        }

    }
}