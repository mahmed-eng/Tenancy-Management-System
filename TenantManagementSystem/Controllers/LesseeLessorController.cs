using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TenantManagementSystem.BLL;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Controllers
{
    public class LesseeLessorController : Controller
    {


        CompanyManager aCompanyManager = new CompanyManager();
        BranchManager aBranchManager = new BranchManager();

        // branchMana aDesignationManager = new DesignationManager();
        LesseeLessorManager aLesseeLessorManager = new LesseeLessorManager();

        [HttpGet]
        public ActionResult SaveLessee()
        {
            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();

            LesseeLessor aLesseeLessor = new LesseeLessor();


            //ViewBag.Branch = adeDepartmentManager.GetAllDepartments();
            //ViewBag.Designations = aDesignationManager.GetAllDesignations();
            return View(aLesseeLessor);
        }

        [HttpGet]
        public JsonResult IsNameExist(LesseeLessor aLesseeLessor)
        {
            bool isExist = false;

            try
            {
                isExist = aLesseeLessorManager.GetAllLesseeLessor().FirstOrDefault(l => l.Name.ToUpper() == aLesseeLessor.Name.ToUpper()) != null;
            }
            catch (Exception ex)
            {
                isExist = false;
            }
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveLessee(LesseeLessor aLesseeLessor)
        {
            // ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();

            aLesseeLessor.CreatedBy = Convert.ToInt16(Session["Id"]);
            aLesseeLessor.CreatedDate = DateTime.Now;
            aLesseeLessor.RecordType = Convert.ToInt16(LesseeLessor.RC.Lessee);
            aLesseeLessor.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aLesseeLessor.BranchId = Convert.ToInt16(Session["BranchId"]);
            ViewBag.Message = aLesseeLessorManager.Save(aLesseeLessor);
            return View(aLesseeLessor);
        }

        [HttpGet]
        public ActionResult SaveLessor()
        {

            LesseeLessor aLesseeLessor = new LesseeLessor();


            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();


            return View(aLesseeLessor);
        }

        [HttpPost]
        public ActionResult SaveLessor(LesseeLessor aLesseeLessor)
        {

            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();

            aLesseeLessor.CreatedBy = Convert.ToInt16(Session["Id"]);
            aLesseeLessor.CreatedDate = DateTime.Now;
            aLesseeLessor.RecordType = Convert.ToInt16(LesseeLessor.RC.Lessor);
            aLesseeLessor.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aLesseeLessor.BranchId = Convert.ToInt16(Session["BranchId"]);
            ViewBag.Message = aLesseeLessorManager.Save(aLesseeLessor);
            return View(aLesseeLessor);
        }
        //Update LesseeLessor
        [HttpGet]
        public ActionResult EditLessor(int id)
        {
            LesseeLessor aLesseeLessor = aLesseeLessorManager.GetLesseeLessorById(id);
            //LesseeLessor aLesseeLessor = new LesseeLessor();
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            //ViewBag.Designations = aDesignationManager.GetAllDesignations();
            return View("EditLessor", aLesseeLessor);
        }

        [HttpPost]
        public ActionResult EditLessor(int id, LesseeLessor aLesseeLessor)
        {
            aLesseeLessor.RecordType = Convert.ToInt16(LesseeLessor.RC.Lessor);
            aLesseeLessor.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aLesseeLessor.UpdatedDate = DateTime.Now;
            aLesseeLessor.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aLesseeLessor.BranchId = Convert.ToInt16(Session["BranchId"]);
            ViewBag.Message = aLesseeLessorManager.Update(aLesseeLessor);
            return View();
        }

        [HttpGet]
        public ActionResult EditLessee(int id)
        {
            LesseeLessor aLesseeLessor = aLesseeLessorManager.GetLesseeLessorById(id);

            //LesseeLessor aLesseeLessor = new LesseeLessor();
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            //ViewBag.Designations = aDesignationManager.GetAllDesignations();
            return View("EditLessee", aLesseeLessor);
        }

        [HttpPost]
        public ActionResult EditLessee(int id, LesseeLessor aLesseeLessor)
        {
            aLesseeLessor.RecordType = Convert.ToInt16(LesseeLessor.RC.Lessee);
            aLesseeLessor.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aLesseeLessor.UpdatedDate = DateTime.Now;
            aLesseeLessor.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aLesseeLessor.BranchId = Convert.ToInt16(Session["BranchId"]);
            ViewBag.Message = aLesseeLessorManager.Update(aLesseeLessor);
            
            return View();
        }

        //delete LesseeLessor
        //[HttpGet]
        //public ActionResult deleteLesseeLessor()
        //{
        //    LesseeLessor aLesseeLessor = new LesseeLessor();

        //    return View(aLesseeLessor);
        //}

        //[HttpPost]
        //public ActionResult deleteLesseeLessor(LesseeLessor aLesseeLessor)
        //{

        //Delete Lessee & Lessor
        [HttpPost]
        public ActionResult DeleteLessee(LesseeLessor aLesseeLessor)
        {

            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();

            aLesseeLessor.CreatedBy = Convert.ToInt16(Session["Id"]);
            aLesseeLessor.CreatedDate = DateTime.Now;
            aLesseeLessor.RecordType = Convert.ToInt16(LesseeLessor.RC.Lessee);
            ViewBag.Message = aLesseeLessorManager.DELETE(aLesseeLessor);
            return View(aLesseeLessor);
        }

        [HttpGet]
        public ActionResult DeleteLessor()
        {

            LesseeLessor aLesseeLessor = new LesseeLessor();


            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();


            return View(aLesseeLessor);
        }

        //----------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int id)
        {
            LesseeLessor aLesseeLessor = aLesseeLessorManager.GetLesseeLessorById(id);

            return View("Edit", aLesseeLessor);
        }

        [HttpPost]
        public ActionResult Edit(int id, LesseeLessor aLesseeLessor)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.LesseeLessor = aLesseeLessorManager.GetAllLesseeLessor();
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aLesseeLessor.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aLesseeLessor.UpdatedDate = DateTime.Now;
            ViewBag.Message = aLesseeLessorManager.Update(aLesseeLessor);
            return View(aLesseeLessor);
        }
        //------------------------------------------------



        [HttpGet]
        public JsonResult IsEmailExist(LesseeLessor aLesseeLessor)
        {
            List<LesseeLessor> LesseeLessor = aLesseeLessorManager.GetAllLesseeLessor();
            bool isExist = LesseeLessor.FirstOrDefault(l => l.Email.ToLowerInvariant().Equals(aLesseeLessor.Email.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLesseeLessorById(int lesseelessorId)
        {
            List<LesseeLessor> lesseeLessorList = aLesseeLessorManager.GetAllLesseeLessor();
            LesseeLessor lesseeLessor = lesseeLessorList.FirstOrDefault(l => l.Id == lesseelessorId);
            return Json(lesseeLessor);
        }

        [HttpGet]
        public ActionResult ViewLessee()
        {

            List<LesseeLessor> LesseeLessorList = aLesseeLessorManager.GetAllLesseeLessor();
            LesseeLessorList = LesseeLessorList.Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessee)).ToList();
            ViewBag.LesseeLessor = LesseeLessorList;
            return View(LesseeLessorList);
        }

        [HttpGet]
        public ActionResult ViewLessor()
        {
            List<LesseeLessor> LesseeLessorList = aLesseeLessorManager.GetAllLesseeLessor();
            LesseeLessorList = LesseeLessorList.Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor)).ToList();
            ViewBag.LesseeLessor = aLesseeLessorManager.GetAllLesseeLessor();
            return View(LesseeLessorList);
        }
    }
}