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
    public class CityController : Controller
    {
        CompanyManager aCompanyManager = new CompanyManager();
        BranchManager aBranchManager = new BranchManager();
        CityManager aCityManager = new CityManager();

        [HttpGet]
        public ActionResult SaveCity()
        {

            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();
            City aCity = new City();

            return View(aCity);
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpPost]
        public ActionResult SaveCity(City aCity)
        {
            ViewBag.Company = aCompanyManager.GetAllCompany();

            ViewBag.Branch = aBranchManager.GetAllBranch();
            aCity.CreatedBy = Convert.ToInt16(Session["Id"]);
            aCity.CreatedDate = DateTime.Now;
            aCity.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aCity.BranchId = Convert.ToInt16(Session["BranchId"]);
            ViewBag.Message = aCityManager.Save(aCity);
            return View();
        }

        //----------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int id)
        {
            City aCity = aCityManager.GetCityById(id);

            return View("Edit", aCity);
        }

        [HttpPost]
        public ActionResult Edit(int id, City aCity)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.City = aCityManager.GetAllCity();
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aCity.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aCity.UpdatedDate = DateTime.Now;
            ViewBag.Message = aCityManager.Update(aCity);
            return View(aCity);
        }
        //------------------------------------------------

        [HttpGet]
        public JsonResult IsEmailExist(City aCity)
        {
            List<City> City = aCityManager.GetAllCity();
            bool isExist = City.FirstOrDefault(t => t.Country.ToLowerInvariant().Equals(aCity.Country.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCityById(City City)
        {
            var Companies = aCityManager.GetAllCity();
            var CityList = Companies.Where(t => t.Id == City.Id).ToList();
            return Json(CityList);
        }

        [HttpGet]
        public ActionResult ViewCity()
        {
            List<City> City = aCityManager.GetAllCity();
            ViewBag.City = aCityManager.GetAllCity();
            return View(City);
        }

    }
}