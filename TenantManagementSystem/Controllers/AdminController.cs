using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eramake;
using TenantManagementSystem.BLL;
using TenantManagementSystem.Models;
using System.Data;
using System.Web.Security;
using System.Web.Mail;
using System.Net.Mail;
//using WebMatrix.WebData;

namespace TenantManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        CompanyManager aCompanyManager = new CompanyManager();
        AdminManager adminManager = new AdminManager();
        DashboardManager aDashboardManager = new DashboardManager();
        BranchManager aBranchManager = new BranchManager();

        [HttpGet]
        public JsonResult IsUserNameExist(Admin aAdmin)
        {
            List<Admin> admins = adminManager.GetAdmin();
            bool isExist = admins.FirstOrDefault(a => a.UserName.ToLowerInvariant().Equals(aAdmin.UserName.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AdminRegister()
        {
            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();
            Admin adminn = new Admin();
            return View(adminn);
        }

        [HttpGet]
        public ActionResult AdminChangePassowrd()
        {
            AdminChangePassowrd adminn = new AdminChangePassowrd();
            return View(adminn);
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            try
            {

                admin.Password = eCryptography.Encrypt(admin.Password);
                ViewBag.Message = adminManager.Save(admin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login1(AdminChangePassowrd changepasswordd)
        {
            changepasswordd.Password = eCryptography.Encrypt(changepasswordd.Password);
            ViewBag.Message = adminManager.SaveChangePassword(changepasswordd);
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Auth(Admin aAdmin)
        {
            try
            {

                var data = adminManager.GetAdmin();
                var adminDetails = data.Where(a => a.UserName == aAdmin.UserName && eCryptography.Decrypt(a.Password) == aAdmin.Password).FirstOrDefault();
                if (adminDetails == null)
                {
                    ViewBag.EMessage = "Wrong User Name or Password";
                    return View("../Admin/Login");
                }
                else if (adminDetails.Name == "admin")
                {
                    Session["Id"] = adminDetails.Id;
                    Session["Name"] = adminDetails.Name;
                    Session["CompanyId"] = adminDetails.CompanyId;
                    Session["BranchId"] = adminDetails.BranchId;
                    //ViewBag.Teachers = aDashboardManager.GetTotalTeacher();
                    //ViewBag.Students = aDashboardManager.GetTotalStudent();
                    //ViewBag.Departments = aDashboardManager.GetTotalDepartment();
                    //ViewBag.Rooms = aDashboardManager.GetTotalRoom();
                    //ViewBag.Chart = aDashboardManager.GetCount();
                    //ViewBag.Company = aDashboardManager.GetCompany();
                    //ViewBag.Branch = aDashboardManager.GetBranch();
                    return View("../Dashboard/Dashboard");
                }
                else
                {
                    Session["Id"] = adminDetails.Id;
                    Session["Name"] = adminDetails.Name;
                    Session["CompanyId"] = adminDetails.CompanyId;
                    Session["BranchId"] = adminDetails.BranchId;
                    ViewBag.Company = aCompanyManager.GetAllCompany();
                    ViewBag.Branch = aBranchManager.GetAllBranch();

                    //ViewBag.Departments = aDashboardManager.GetTotalDepartment();
                    //ViewBag.Rooms = aDashboardManager.GetTotalRoom();
                    //ViewBag.Chart = aDashboardManager.GetCount();
                    return View("../Dashboard/Dashboard");
                }

            }
            catch (Exception ex)
            {
                    throw ex;
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
    }
}