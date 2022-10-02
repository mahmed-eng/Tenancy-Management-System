using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TenantManagementSystem.Models
{
    public class PropertyVM
    {
        public int Id { get; set; }
        public string PropertyNumber { get; set; }

        public int CompanyId { get; set; }
        public int BranchId { get; set; }


        public int AreaId { get; set; }

        [Display(Name = "Area Name")]
        public string AreaName { get; set; }


        public int CityId { get; set; }

        [Display(Name = "City Name")]
        public string CityName { get; set; }


        public int LessorId { get; set; }

        [Display(Name = "Lesser Name")]
        public string LessorName { get; set; }

        public int BuildingId { get; set; }

        [Display(Name = "Building Name")]
        public string BuildingName { get; set; }

        //[Remote("IsFlatExist", "Property", ErrorMessage = "Flat Already Exist in Building")]

        [Required(ErrorMessage = "Please Enter a Name")]
        public string Name { get; set; }

        [Display(Name = "Flat Number")]
        [Required(ErrorMessage = "Please Enter a Number")]
        public string FlatNumber { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please Insert Address")]
        public string Address { get; set; }

        [Display(Name = "Property Type")]
        public int PropertyType { get; set; }


        [Display(Name = "Property Type Name")]
        public string PropertyTypeName { get; set; }

        public int FlatTypeId { get; set; }

        [Display(Name = "Flat Type")]
        public string FlatTypeName { get; set; }


        //public string CardNumber { get; set; }

        [Display(Name = "Bond Type")]
        public string BondType { get; set; }


        [Display(Name = "Bond Number")]
        public string BondNumber { get; set; }

        [Display(Name = "Government Number")]
        public string GovernmentNumber { get; set; }

        public string PilotNumber { get; set; }

        public string Street { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }



        public enum PT
        {
            Building,  //0
            Vellas,   //1
            Flat,     //2
            Shop
        }


    }
}