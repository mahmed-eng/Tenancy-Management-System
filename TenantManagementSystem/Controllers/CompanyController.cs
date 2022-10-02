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
    public class CompanyController : Controller
    {
        // DepartmentManager aDepartmentManager = new DepartmentManager();
        // DesignationManager aDesignationManager = new DesignationManager();
        CompanyManager aCompanyManager = new CompanyManager();

        [HttpGet]
        public ActionResult SaveCompany()
        {
            Company aCompany = new Company();
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            //ViewBag.Designations = aDesignationManager.GetAllDesignations();
            return View(aCompany);
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpPost]
        public ActionResult SaveCompany(Company aCompany)
        {
            aCompany.CreatedBy = Convert.ToInt16(Session["Id"]);
            aCompany.CreatedDate = DateTime.Now;
            ViewBag.Message = aCompanyManager.Save(aCompany);
            return View();
        }

        //----------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Company aCompany = aCompanyManager.GetCompanyById(id);

            return View("Edit", aCompany);
        }

        [HttpPost]
        public ActionResult Edit(int id, Company aCompany)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aCompany.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aCompany.UpdatedDate = DateTime.Now;
            ViewBag.Message = aCompanyManager.Update(aCompany);
            return View(aCompany);
        }
        //------------------------------------------------

        [HttpGet]
        public JsonResult IsEmailExist(Company aCompany)
        {
            List<Company> Company = aCompanyManager.GetAllCompany();
            bool isExist = Company.FirstOrDefault(t => t.Email.ToLowerInvariant().Equals(aCompany.Email.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanyById(Company company)
        {
            var Companies = aCompanyManager.GetAllCompany();
            var CompanyList = Companies.Where(t => t.CompanyId == company.CompanyId).ToList();
            return Json(CompanyList);
        }

        [HttpGet]
        public ActionResult ViewCompany()
        {
            List<Company> Company = aCompanyManager.GetAllCompany();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            return View(Company);
        }
        // To fill data in the form
        // to enable easy editing
        //[HttpPut]
        //public ActionResult Edit(int BranchId)
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        var data = context.Branch.Where(x => x.BranchId == BranchId).SingleOrDefault();
        //        return View(data);
        //    }
        //}
    }
}
