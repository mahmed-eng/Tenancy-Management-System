using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TenantManagementSystem.BLL;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Controllers
{
    public class PropertyController : Controller
    {


        CompanyManager aCompanyManager = new CompanyManager();
        BranchManager aBranchManager = new BranchManager();
        AreaManager aAreaManager = new AreaManager();
        CityManager aCityManager = new CityManager();
        LesseeLessorManager aLesseeLessorManager = new LesseeLessorManager();
        PropertyManager aPropertyManager = new PropertyManager();
        List<Property> PropertyList = new List<Property>();

        [HttpGet]
        public ActionResult ViewBuildingVillas()
        {
            PropertyList = new List<Property>();
            try
            {
                PropertyList = aPropertyManager.GetAllProperty();
                PropertyList = PropertyList.Where(l => l.PropertyType != Convert.ToInt16(Property.PT.Flat)).ToList();
                ViewBag.Property = aPropertyManager.GetAllProperty();
                ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor));
                ViewBag.PropertyType = aPropertyManager.GetAllPropertyType();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " " + ex.InnerException;
            }
            return View(PropertyList);
        }

        [HttpPost]
        public JsonResult ViewPropertyBySelection(int Id)
        {
            PropertyList = new List<Property>();
            try
            {
                PropertyList = aPropertyManager.GetAllProperty();
                PropertyList = PropertyList.Where(l => l.PropertyType == Id).ToList();
                ViewBag.Property = aPropertyManager.GetAllProperty();
                ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor));
                ViewBag.PropertyType = aPropertyManager.GetAllPropertyTypeNoFlat();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " " + ex.InnerException;
            }
            return Json(PropertyList, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult ViewPropertyBySelectionUO()
        {
            PropertyList = new List<Property>();
            try
            {
                PropertyList = aPropertyManager.GetAllProperty();
                PropertyList = PropertyList.Where(l => l.PropertyType != Convert.ToInt16(Property.PT.Flat)).ToList();
                ViewBag.Property = aPropertyManager.GetAllProperty();
                ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor));
                ViewBag.PropertyType = aPropertyManager.GetAllPropertyType();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " " + ex.InnerException;
            }

            return View();
        }

        [HttpPost]
        public JsonResult ViewPropertyBySelectionUO(int Id)
        {
            PropertyList = new List<Property>();
            try
            {
                PropertyList = aPropertyManager.GetAllPropertyUO();
                ViewBag.Property = PropertyList;
                PropertyList = PropertyList.Where(l => l.BuildingId != 0).ToList();
                //PropertyList = PropertyList.Where(l => l.LessorId == Id).ToList();

                ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor)).ToList();
                ViewBag.PropertyType = aPropertyManager.GetAllPropertyTypeNoFlat();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " " + ex.InnerException;
            }
            return Json(PropertyList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ViewPropertyBySelectionO()
        {
            PropertyList = new List<Property>();
            try
            {
                PropertyList = aPropertyManager.GetAllProperty();
                PropertyList = PropertyList.Where(l => l.PropertyType != Convert.ToInt16(Property.PT.Flat)).ToList();
                ViewBag.Property = aPropertyManager.GetAllProperty();
                ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor)).ToList();
                ViewBag.PropertyType = aPropertyManager.GetAllPropertyType();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " " + ex.InnerException;
            }
            return View();
        }

        [HttpPost]
        public JsonResult ViewPropertyBySelectionO(int Id)
        {
            PropertyList = new List<Property>();
            try
            {
                PropertyList = aPropertyManager.GetAllPropertyO();
                //PropertyList = PropertyList.Where(l => l.LessorId == Id).ToList();
                ViewBag.Property = aPropertyManager.GetAllProperty();
                ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor)).ToList();
                ViewBag.PropertyType = aPropertyManager.GetAllPropertyTypeNoFlat();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " " + ex.InnerException;
            }
            return Json(PropertyList, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult ViewPropertyBySelection()
        {
            PropertyList = new List<Property>();
            try
            {
                PropertyList = aPropertyManager.GetAllProperty();
                PropertyList = PropertyList.Where(l => l.PropertyType != Convert.ToInt16(Property.PT.Flat)).ToList();
                ViewBag.Property = aPropertyManager.GetAllProperty();
                ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor));
                ViewBag.PropertyType = aPropertyManager.GetAllPropertyType();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " " + ex.InnerException;
            }
            return View();
        }

        [HttpGet]
        public ActionResult SaveBuildingVillas()
        {
            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();

            Property aProperty = new Property();

            ViewBag.City = aCityManager.GetAllCity();
            ViewBag.Area = aAreaManager.GetAllArea();
            ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor)).ToList();
            ViewBag.PropertyType = aPropertyManager.GetAllPropertyTypeNoFlat();

            //ViewBag.Branch = adeDepartmentManager.GetAllDepartments();
            //ViewBag.Designations = aDesignationManager.GetAllDesignations();
            return View(aProperty);
        }

        [HttpPost]
        public ActionResult SaveBuildingVillas(Property aProperty)
        {
            try
            {
                //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
                //ViewBag.Designations = aDesignationManager.GetAllDesignations();
                ViewBag.Company = aCompanyManager.GetAllCompany();
                ViewBag.Branch = aBranchManager.GetAllBranch();

                aProperty.CreatedBy = Convert.ToInt16(Session["Id"]);
                aProperty.CreatedDate = DateTime.Now;
                aProperty.CompanyId = Convert.ToInt16(Session["CompanyId"]);
                aProperty.BranchId = Convert.ToInt16(Session["BranchId"]);
                //  aProperty.BondType = Convert.ToInt16(Property.PT.Flat);
                ViewBag.Message = aPropertyManager.Save(aProperty);
                ViewBag.City = aCityManager.GetAllCity();
                ViewBag.Area = aAreaManager.GetAllArea();
                ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor));
                ViewBag.PropertyType = aPropertyManager.GetAllPropertyTypeNoFlat();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " " + ex.InnerException;
            }
            return View(aProperty);
        }


        [HttpGet]
        public ActionResult ViewFlat()
        {
            PropertyList = new List<Property>();
            try
            {
                PropertyList = aPropertyManager.GetAllProperty();
                PropertyList = PropertyList.Where(l => l.PropertyType == Convert.ToInt16(Property.PT.Flat)).ToList();
                ViewBag.Property = aPropertyManager.GetAllProperty();
                ViewBag.City = aCityManager.GetAllCity();
                ViewBag.Area = aAreaManager.GetAllArea();
                ViewBag.FlatType = aPropertyManager.GetFlatType();
                ViewBag.Building = aPropertyManager.GetAllBuildings();
                ViewBag.Flat = aPropertyManager.GetAllProperty();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " " + ex.InnerException;
            }
            return View(PropertyList);
        }




        [HttpGet]
        public ActionResult ViewProperty()
        {
            List<PropertyVM> PropertyList = new List<PropertyVM>();
            try
            {
                PropertyList = aPropertyManager.GetAllPropertyVM();
                //PropertyList = PropertyList.Where(l => l.PropertyType == Convert.ToInt16(Property.PT.Flat)).ToList();
                //ViewBag.Property = aPropertyManager.GetAllProperty();
                //ViewBag.City = aCityManager.GetAllCity();
                //ViewBag.Area = aAreaManager.GetAllArea();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " " + ex.InnerException;
            }
            return View(PropertyList);
        }

        [HttpGet]
        public ActionResult SaveFlat()
        {

            Property aProperty = new Property();


            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();
            ViewBag.FlatType = aPropertyManager.GetFlatType();
            ViewBag.City = aCityManager.GetAllCity();
            ViewBag.Area = aAreaManager.GetAllArea();
            ViewBag.Building = aPropertyManager.GetAllBuildings();
            ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor));
            ViewBag.Flat = aPropertyManager.GetAllProperty();

            return View(aProperty);
        }

        [HttpPost]
        public ActionResult SaveFlat(Property aProperty)
        {

            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();

            ViewBag.FlatType = aPropertyManager.GetFlatType();

            //aProperty.Name = aProperty.FlatNo;
            aProperty.CreatedBy = Convert.ToInt16(Session["Id"]);
            aProperty.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aProperty.BranchId = Convert.ToInt16(Session["BranchId"]);
            aProperty.CreatedDate = DateTime.Now;
            aProperty.PropertyType = Convert.ToInt16(Property.PT.Flat);


            if (aProperty.Name.Contains(','))
            {
                List<string> FlatNos = aProperty.Name.Split(',').ToList<string>();

                foreach (var item in FlatNos)
                {

                    aProperty.Name = aProperty.PropertyNumber = item.Trim();
                    //aProperty.PropertyNumber = item;
                    ViewBag.Message = aPropertyManager.Save(aProperty);
                }

            }
            else
                // aProperty.BondType = Convert.ToInt16(Property.RC.Vellas);
                ViewBag.Message = aPropertyManager.Save(aProperty);

            ViewBag.City = aCityManager.GetAllCity();
            ViewBag.Area = aAreaManager.GetAllArea();
            ViewBag.Building = aPropertyManager.GetAllBuildings();
            ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor));
            ViewBag.Flat = aPropertyManager.GetAllFlats();

            return View(aProperty);
        }

        [HttpGet]
        public ActionResult ViewShop()
        {
            PropertyList = new List<Property>();
            try
            {
                PropertyList = aPropertyManager.GetAllProperty();
                PropertyList = PropertyList.Where(l => l.PropertyType == Convert.ToInt16(Property.PT.Shop)).ToList();
                ViewBag.Property = aPropertyManager.GetAllProperty();
                ViewBag.City = aCityManager.GetAllCity();
                ViewBag.Area = aAreaManager.GetAllArea();
                //ViewBag.FlatType = aPropertyManager.GetFlatType();
                ViewBag.Building = aPropertyManager.GetAllBuildings();
                //ViewBag.Flat = aPropertyManager.GetAllProperty();
                ViewBag.Shop = aPropertyManager.GetAllShops();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " " + ex.InnerException;
            }

            return View(PropertyList);
        }

        [HttpGet]
        public ActionResult SaveShop()
        {

            Property aProperty = new Property();


            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();
            //ViewBag.FlatType = aPropertyManager.GetFlatType();
            ViewBag.City = aCityManager.GetAllCity();
            ViewBag.Area = aAreaManager.GetAllArea();
            ViewBag.Building = aPropertyManager.GetAllBuildings();
            // ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor();
            //ViewBag.Flat = aPropertyManager.GetAllProperty();
            ViewBag.Shop = aPropertyManager.GetAllShops();

            return View(aProperty);
        }

        [HttpPost]
        public ActionResult SaveShop(Property aProperty)
        {

            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();

            //ViewBag.FlatType = aPropertyManager.GetFlatType();

            //aProperty.Name = aProperty.FlatNo;
            aProperty.PropertyNumber = aProperty.Name;
            aProperty.CreatedBy = Convert.ToInt16(Session["Id"]);
            aProperty.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aProperty.BranchId = Convert.ToInt16(Session["BranchId"]);
            aProperty.CreatedDate = DateTime.Now;
            aProperty.PropertyType = Convert.ToInt16(Property.PT.Shop);


            if (aProperty.Name.Contains(','))
            {
                List<string> FlatNos = aProperty.Name.Split(',').ToList<string>();

                foreach (var item in FlatNos)
                {
                    //aProperty.Name = item;
                    //aProperty.PropertyNumber = item;
                    aProperty.Name = aProperty.PropertyNumber = item.Trim();
                    ViewBag.Message = aPropertyManager.Save(aProperty);
                }

            }
            else
                // aProperty.BondType = Convert.ToInt16(Property.RC.Vellas);
                ViewBag.Message = aPropertyManager.Save(aProperty);

            //ViewBag.Message = aPropertyManager.Save(aProperty);


            ViewBag.City = aCityManager.GetAllCity();
            ViewBag.Area = aAreaManager.GetAllArea();
            ViewBag.Building = aPropertyManager.GetAllBuildings();
            //ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor();
            //ViewBag.Flat = aPropertyManager.GetAllFlats();
            ViewBag.Shop = aPropertyManager.GetAllShops();

            return View(aProperty);
        }

        [HttpGet]
        public JsonResult IsFlatExist(Property aProperty)
        {
            PropertyList = new List<Property>();
            bool isExist = false;
            try
            {
                aProperty.FlatTypeId = Convert.ToInt16(Property.PT.Flat);

                PropertyList = aPropertyManager.GetAllFlats();
                //bool isExist = PropertyList.FirstOrDefault(l => l.BuildingId == aProperty.BuildingId && l.Name.ToUpper() == aProperty.Name.ToUpper()) != null;
                isExist = PropertyList.FirstOrDefault(l => l.Name.ToUpper() == aProperty.Name.ToUpper()) != null;
                PropertyList = PropertyList.Where(l => l.PropertyType == Convert.ToInt16(Property.PT.Flat)).ToList();

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " " + ex.InnerException;
            }
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult IsBuildingExist(Property aProperty)
        {
            PropertyList = new List<Property>();
            bool isExist = false;
            try
            {
                aProperty.FlatTypeId = Convert.ToInt16(Property.PT.Flat);

                List<Property> PropertyList = aPropertyManager.GetAllProperty().Where(l => l.PropertyType != Convert.ToInt16(Property.PT.Flat)).ToList();
                //bool isExist = PropertyList.FirstOrDefault(l => l.BuildingId == aProperty.BuildingId && l.Name.ToUpper() == aProperty.Name.ToUpper()) != null;
                isExist = PropertyList.FirstOrDefault(l => l.Name.ToUpper() == aProperty.Name.ToUpper()) != null;
                PropertyList = PropertyList.Where(l => l.PropertyType != Convert.ToInt16(Property.PT.Flat)).ToList();

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + " " + ex.InnerException;
            }
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        //----------------------------------------------------
        [HttpGet]
        public ActionResult EditBuildingVillas(int id)
        {
            Property aProperty = aPropertyManager.GetPropertyById(id);
            ViewBag.City = aCityManager.GetAllCity();
            ViewBag.Area = aAreaManager.GetAllArea();
            ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor));
            ViewBag.PropertyType = aPropertyManager.GetAllPropertyType();
            return View("EditBuildingVillas", aProperty);
        }

        [HttpPost]
        public ActionResult EditBuildingVillas(int id, Property aProperty)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Property = aPropertyManager.GetAllProperty();
            //ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aProperty.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aProperty.UpdatedDate = DateTime.Now;
            aProperty.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aProperty.BranchId = Convert.ToInt16(Session["BranchId"]);

            ViewBag.Message = aPropertyManager.Update(aProperty);
            ViewBag.City = aCityManager.GetAllCity();
            ViewBag.Area = aAreaManager.GetAllArea();
            ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor));
            ViewBag.Building = aPropertyManager.GetAllProperty();
            ViewBag.PropertyType = aPropertyManager.GetAllPropertyType();
            return View(aProperty);
        }
        //------------------------------------------------


        //----------------------------------------------------
        [HttpGet]
        public ActionResult EditFlat(int id)
        {
            Property aProperty = aPropertyManager.GetPropertyById(id);
            ViewBag.City = aCityManager.GetAllCity();
            ViewBag.Area = aAreaManager.GetAllArea();
            ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor));
            ViewBag.Flat = aPropertyManager.GetAllProperty();
            ViewBag.FlatType = aPropertyManager.GetFlatType();
            ViewBag.Shop = aPropertyManager.GetAllShops();
            ViewBag.Building = aPropertyManager.GetAllProperty().Where(l => l.PropertyType == Convert.ToInt16(Property.PT.Building)).ToList();
            return View("EditFlat", aProperty);
        }

        [HttpPost]
        public ActionResult EditFlat(int id, Property aProperty)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Property = aPropertyManager.GetAllProperty();
            //ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aProperty.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aProperty.UpdatedDate = DateTime.Now;
            aProperty.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aProperty.BranchId = Convert.ToInt16(Session["BranchId"]);
            aProperty.PropertyType = Convert.ToInt16(Session["PropertyType"]);

            ViewBag.Message = aPropertyManager.Update(aProperty);
            ViewBag.City = aCityManager.GetAllCity();
            ViewBag.Area = aAreaManager.GetAllArea();
            ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor().Where(l => l.RecordType == Convert.ToInt16(LesseeLessor.RC.Lessor));
            ViewBag.Flat = aPropertyManager.GetAllProperty();
            ViewBag.FlatType = aPropertyManager.GetFlatType();
            ViewBag.Building = aPropertyManager.GetAllFlats();
            ViewBag.Shop = aPropertyManager.GetAllShops();

            return View(aProperty);
        }
        //------------------------------------------------

        //Edit Shop
        [HttpGet]
        public ActionResult EditShop(int id)
        {
            Property aProperty = aPropertyManager.GetPropertyById(id);
            ViewBag.City = aCityManager.GetAllCity();
            ViewBag.Area = aAreaManager.GetAllArea();
            //ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor();
            //ViewBag.Flat = aPropertyManager.GetAllProperty();
            //ViewBag.FlatType = aPropertyManager.GetFlatType();
            ViewBag.Building = aPropertyManager.GetAllProperty().Where(l => l.PropertyType == Convert.ToInt16(Property.PT.Building)).ToList();
            return View("EditShop", aProperty);
        }

        [HttpPost]
        public ActionResult EditShop(int id, Property aProperty)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Property = aPropertyManager.GetAllProperty();
            //ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aProperty.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aProperty.UpdatedDate = DateTime.Now;
            aProperty.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aProperty.BranchId = Convert.ToInt16(Session["BranchId"]);
            aProperty.PropertyType = Convert.ToInt16(Session["PropertyType"]);

            ViewBag.Message = aPropertyManager.Update(aProperty);
            ViewBag.City = aCityManager.GetAllCity();
            ViewBag.Area = aAreaManager.GetAllArea();
            //ViewBag.Lessor = aLesseeLessorManager.GetAllLesseeLessor();
            //ViewBag.Flat = aPropertyManager.GetAllProperty();
            //ViewBag.FlatType = aPropertyManager.GetFlatType();
            ViewBag.Building = aPropertyManager.GetAllFlats();

            return View(aProperty);
        }
        //------------------------------------------------

        //Delete Property & Property
        [HttpPost]
        public ActionResult DeleteProperty(Property aProperty)
        {

            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();
            ViewBag.Building = aPropertyManager.GetAllProperty();

            aProperty.CreatedBy = Convert.ToInt16(Session["Id"]);
            aProperty.CreatedDate = DateTime.Now;
            // aProperty.BondType = Convert.ToInt16(Property.RC.Flat);
            ViewBag.Message = aPropertyManager.DELETE(aProperty);
            return View(aProperty);
        }

        [HttpGet]
        public ActionResult DeleteProperty()
        {

            Property aProperty = new Property();


            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();


            return View(aProperty);
        }




        [HttpGet]

        public JsonResult GetPropertyById(int PropertyId)
        {
            List<Property> PropertyList = aPropertyManager.GetAllProperty();
            Property Property = PropertyList.FirstOrDefault(l => l.Id == PropertyId);
            return Json(Property);
        }
    }
}