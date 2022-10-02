using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TenantManagementSystem.BLL;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Controllers
{
    public class ChequeDetailsController : Controller
    {


        //LesseeLessorManager aLesseeLessorManager = new LesseeLessorManager();
        BranchManager aBranchManager = new BranchManager();
        //BranchManager aCompanyManager = new CompanyManager();
        //AreaManager aAreaManager = new AreaManager();
        PropertyManager aPropertyManager = new PropertyManager();
        TenancyAgreementManager aTenancyAgreementManager = new TenancyAgreementManager();
        ChequeDetailsManager aChequeDetailsManager = new ChequeDetailsManager();
        CompanyManager aCompanyManager = new CompanyManager();
        LesseeLessorManager aLesseeLessorManager = new LesseeLessorManager();
        List<TenancyAgreement> taList;
        TenancyAgreement ta;

        [HttpGet]
        public ActionResult ViewChequeDetails()
        {

            List<ChequeDetails> chequeDetailsList = aChequeDetailsManager.GetAllChequeDetails();
            //PropertyList = PropertyList.Where(l => l.PropertyType != Convert.ToInt16(Property.PT.Flat)).ToList();
            ViewBag.Tenancy = aTenancyAgreementManager.GetAllTenancyAgreement();
            //newly comment
            //ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor();
            //ViewBag.building = aPropertyManager.GetAllProperty();
            //ViewBag.Property = aPropertyManager.GetAllProperty();
            //ViewBag.Flat = aPropertyManager.GetAllProperty();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();


            return View(chequeDetailsList);
        }

        [HttpPost]
        public JsonResult ViewPendingCheques(int? BuildingId, DateTime? FromDate, DateTime? ToDate, int? pendingcheques)
        {
            bool isCashed = pendingcheques == 1 ? false : true;
            List<ChequeDetails> chequeDetailsList = aChequeDetailsManager.GetAllChequeDetailsView();
            chequeDetailsList = chequeDetailsList.Where(t=> (t.ChequeDate >= FromDate && t.ChequeDate <= ToDate) && t.BuildingId == BuildingId && t.IsCashed == isCashed).ToList() ;
            //PropertyList = PropertyList.Where(l => l.PropertyType != Convert.ToInt16(Property.PT.Flat)).ToList();
            //ViewBag.Tenancy = aTenancyAgreementManager.GetAllTenancyAgreement();
            //newly comment
            //ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor();
            //ViewBag.building = aPropertyManager.GetAllProperty();
          //  ViewBag.Property = aPropertyManager.GetAllProperty();
            //ViewBag.Flat = aPropertyManager.GetAllProperty();
            //  ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor)).ToList();
            //ViewBag.Company = aCompanyManager.GetAllCompany();
            //ViewBag.Branch = aBranchManager.GetAllBranch();
           ViewBag.Property = aPropertyManager.GetAllProperty().Where(l => l.PropertyType == Convert.ToInt16(Property.PT.Building)).ToList();

            return Json(chequeDetailsList, JsonRequestBehavior.AllowGet);
            
        }

        [HttpGet]
        public ActionResult ViewPendingCheques()
        {

            //List<ChequeDetails> chequeDetailsList = aChequeDetailsManager.GetAllChequeDetails();
            //PropertyList = PropertyList.Where(l => l.PropertyType != Convert.ToInt16(Property.PT.Flat)).ToList();
            //ViewBag.Tenancy = aTenancyAgreementManager.GetAllTenancyAgreement();
            //newly comment
            //ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor();
            //ViewBag.building = aPropertyManager.GetAllProperty();
            ViewBag.Property = aPropertyManager.GetAllProperty().Where(l => l.PropertyType == Convert.ToInt16(Property.PT.Building)).ToList(); 
            //ViewBag.Flat = aPropertyManager.GetAllProperty();
           // ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor)).ToList();
            //ViewBag.Company = aCompanyManager.GetAllCompany();
            //ViewBag.Branch = aBranchManager.GetAllBranch();


            return View();
        }


        [HttpPost]
        public ActionResult SaveChequeDetails(ChequeDetails aChequeDetails)
        {
            try
            {

            
            aChequeDetails.CreatedBy = Convert.ToInt16(Session["Id"]);
            aChequeDetails.CreatedDate = DateTime.Now;
            aChequeDetails.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aChequeDetails.BranchId = Convert.ToInt16(Session["BranchId"]);

            if (string.IsNullOrEmpty(Convert.ToString(aChequeDetails.TenantAgreementId)) || aChequeDetails.TenantAgreementId == 0)
            {
                taList = aTenancyAgreementManager.GetAllTenancyAgreement().ToList();
                ta = taList.Where(t => t.AgreementNumber == aChequeDetails.TenantAgreementNumber).FirstOrDefault();
                aChequeDetails.TenantAgreementId = ta.Id;
            }

            ViewBag.ChequeDetails = aChequeDetailsManager.GetAllChequeDetails();
            ViewBag.Message = aChequeDetailsManager.Save(aChequeDetails);

            ViewBag.Tenancy = taList = aTenancyAgreementManager.GetAllTenancyAgreement();

                //if (taList.Count>0)
                //{
                //    aChequeDetails.TenantAgreementId = taList.Where(t => t.AgreementNumber == aChequeDetails.TenantAgreementNumber).FirstOrDefault().Id;
                //}

                //ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor();
                //ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.Id == Convert.ToInt16(LesseeLessor.RC.Lessor));
                //aChequeDetails.CreatedBy = Convert.ToInt16(Session["Id"]);
                //aChequeDetails.CreatedDate = DateTime.Now;
                //ViewBag.Flat = aPropertyManager.GetAllProperty().Where(t => t.PropertyType == Convert.ToInt16(Property.PT.Flat));

            }
            catch (Exception EX)
            {
                ViewBag.Message = EX.Message +  " "+ EX.InnerException;
            }

            return View(aChequeDetails);
        }

        //

        [HttpGet]
        public ActionResult SaveChequeDetails()
        {
            //ViewBag.Company = aCompanyManager.GetAllCompany();
            //ViewBag.Branch = aBranchManager.GetAllBranch();

            TenancyAgreement aTenancyAgreement = new TenancyAgreement();

            ViewBag.Tenancy = aTenancyAgreementManager.GetAllTenancyAgreement();
            //ViewBag.Area = aAreaManager.GetAllArea();

            //ViewBag.Building = aPropertyManager.GetAllProperty().Where(t => t.PropertyType == Convert.ToInt16(Property.PT.Building));
            //ViewBag.Tenancy = aPropertyManager.GetAllProperty().Where(t => t.PropertyType == Convert.ToInt16(Property.PT.Flat));

            //ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.Id == Convert.ToInt16(LesseeLessor.RC.Lessor));
            //ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l=> l.Name .All(LesseeLessor.RC.Lessor));
            //ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor();
            //ViewBag.Branch = adeDepartmentManager.GetAllDepartments();
            //ViewBag.Designations = aDesignationManager.GetAllDesignations();

            ChequeDetails aChequeDetails = new ChequeDetails();

            return View(aChequeDetails);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ChequeDetails aChequeDetails = aChequeDetailsManager.GetAllChequeDetailsById(id);

            return View("Edit", aChequeDetails);
        }

        [HttpPost]
        public ActionResult Edit(int id, ChequeDetails aChequeDetails)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.ChequeDetails = aChequeDetailsManager.GetAllChequeDetails();
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aChequeDetails.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aChequeDetails.UpdatedDate = DateTime.Now;
            ViewBag.Message = aChequeDetailsManager.Update(aChequeDetails);
            return View(aChequeDetails);
        }

































        //----------------------------------------------------
        //[HttpGet]
        //public ActionResult EditBuildingVillas(int id)
        //{
        //    Property aProperty = aPropertyManager.GetPropertyById(id);
        //    ViewBag.City = aCityManager.GetAllCity();
        //    ViewBag.Area = aAreaManager.GetAllArea();

        //    return View("Edit", aProperty);
        //}

        //[HttpPost]
        //public ActionResult EditBuildingVillas(int id, Property aProperty)
        //{
        //    //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
        //    ViewBag.Property = aPropertyManager.GetAllProperty();
        //    // ViewBag.Designations = aDesignationManager.GetAllDesignations();

        //    aProperty.UpdatedBy = Convert.ToInt16(Session["Id"]);
        //    aProperty.UpdatedDate = DateTime.Now;
        //    ViewBag.Message = aPropertyManager.Update(aProperty);
        //    ViewBag.City = aCityManager.GetAllCity();
        //    ViewBag.Area = aAreaManager.GetAllArea();

        //    return View(aProperty);
        //}
        //------------------------------------------------


        //----------------------------------------------------



        //------------------------------------------------


        //Delete Property & Property
        //[HttpPost]
        //public ActionResult DeleteProperty(Property aProperty)
        //{

        //    ViewBag.Company = aCompanyManager.GetAllCompany();
        //    ViewBag.Branch = aBranchManager.GetAllBranch();

        //    aProperty.CreatedBy = Convert.ToInt16(Session["Id"]);
        //    aProperty.CreatedDate = DateTime.Now;
        //   // aProperty.BondType = Convert.ToInt16(Property.RC.Flat);
        //    ViewBag.Message = aPropertyManager.DELETE(aProperty);
        //    return View(aProperty);
        //}

        //[HttpGet]
        //public ActionResult DeleteProperty()
        //{

        //    Property aProperty = new Property();


        //    ViewBag.Company = aCompanyManager.GetAllCompany();
        //    ViewBag.Branch = aBranchManager.GetAllBranch();


        //    return View(aProperty);
        //}
















        [HttpGet]

        public JsonResult GetChequeDetailsId(int ChequeDetailsId)
        {
            List<ChequeDetails> ChequeDetailsList = aChequeDetailsManager.GetAllChequeDetails();
            ChequeDetails chequeDetails = ChequeDetailsList.FirstOrDefault(l => l.Id == ChequeDetailsId);
            return Json(chequeDetails);
        }
        [HttpGet]

        public JsonResult GetAllChequeDetails()
        {
            List<ChequeDetails> chequeDetailsList = aChequeDetailsManager.GetAllChequeDetails();

            return Json(chequeDetailsList);
        }



    }
}