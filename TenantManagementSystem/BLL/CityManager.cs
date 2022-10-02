using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenantManagementSystem.Gateway;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.BLL
{
    public class CityManager
    {
        CityGateway aCityGateway = new CityGateway();
        string successMessage = string.Empty;

        public string Save(City aCity)
        {
            if (aCityGateway.Save(aCity) > 0)
            {
                return "City Save Successfully!!";
            }
            else
            {
                return "Failed";
            }
        }

        public string Update(City aCity)
        {
            try
            {
                if (aCityGateway.Update(aCity) > 0)
                {
                    successMessage = "City Save Successfully!!";
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

        public List<City> GetAllCity()
        {
            return aCityGateway.GetAllCity();
        }

        public City GetCityById(int CityId)
        {
            var cities = GetAllCity();
            City city = cities.FirstOrDefault(t => t.Id == CityId);
            return city;
        }

    }
}