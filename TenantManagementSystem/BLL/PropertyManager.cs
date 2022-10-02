using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenantManagementSystem.Gateway;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.BLL
{
    public class PropertyManager
    {
        PropertyGateway aPropertyGateway = new PropertyGateway();
        string successMessage = string.Empty;

        public string Save(Property aProperty)
        {
            if (aPropertyGateway.Save(aProperty) > 0)
            {
                return "Save Successfully!";
            }
            else
            {
                return "Failed";
            }
        }

        //Update
        public string UPDATE(Property aProperty)
        {
            if (aPropertyGateway.Update(aProperty) > 0)
            {
                return "Save Successfully!";
            }
            else
            {
                return "Failed";
            }
        }


        //Delete
        public string DELETE(Property aProperty)
        {
            if (aPropertyGateway.Delete(aProperty) > 0)
            {
                return "Delete Successfully!";
            }
            else
            {
                return "Failed";
            }
        }

        public string Update(Property aProperty)
        {
            try
            {
                if (aPropertyGateway.Update(aProperty) > 0)
                {
                    successMessage = "Property Save Successfully!!";
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


        //View
        //public string DELETE(Property aProperty)
        //{
        //    if (aPropertyGateway.Delete(aProperty) > 0)
        //    {
        //        return "Delete Successfully!";
        //    }
        //    else
        //    {
        //        return "Failed";
        //    }
        //}



        public List<Property> GetAllProperty()
        {
            return aPropertyGateway.GetAllProperty();
        }

        public List<Property> GetAllFlats()
        {
            return aPropertyGateway.GetAllProperty().Where(l => l.PropertyType == Convert.ToInt16(Property.PT.Flat)).ToList();
        }
        public List<Property> GetAllBuildings()
        {
            return aPropertyGateway.GetAllProperty().Where(l => l.PropertyType == Convert.ToInt16(Property.PT.Building)).ToList();
        }
        public List<Property> GetAllVillas()
        {
            return aPropertyGateway.GetAllProperty().Where(l => l.PropertyType == Convert.ToInt16(Property.PT.Vellas)).ToList();
        }
        public List<Property> GetAllShops()
        {
            return aPropertyGateway.GetAllProperty().Where(l => l.PropertyType == Convert.ToInt16(Property.PT.Shop)).ToList(); ;
        }


        public List<Property> GetAllPropertyUO()
        {
            return aPropertyGateway.GetAllPropertyUO();
        }

        public List<Property> GetAllPropertyO()
        {
            return aPropertyGateway.GetAllPropertyO();
        }


        public List<PropertyType> GetAllPropertyTypeNoFlat()
        {
            return aPropertyGateway.GetAllPropertyTypeNoFlat();
        }

        public List<PropertyType> GetAllPropertyType()
        {
            return aPropertyGateway.GetAllPropertyType();
        }
        public List<PropertyVM> GetAllPropertyVM()
        {
            return aPropertyGateway.GetAllPropertyVM();
        }
        public Property GetPropertyById(int PropertyId)
        {
            var Propertys = GetAllProperty();
            Property Property = Propertys.FirstOrDefault(t => t.Id == PropertyId);
            return Property;
        }


        public List<FlatType> GetFlatType()
        {
            return aPropertyGateway.GetFlatType();
        }

    }
}