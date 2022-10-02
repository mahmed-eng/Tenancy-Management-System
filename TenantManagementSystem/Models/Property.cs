using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TenantManagementSystem.Models
{
    public class Property
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

        public int FlatId { get; set; }

        public int LessorId { get; set; }

        [Display(Name = "Lessor Name")]
        public string LessorName { get; set; }

        public string LesssorCellNo { get; set; }

        [Remote("IsFlatExist", "Property", ErrorMessage = "Mentioned propert already exist")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please Enter a Name")]
        public string Name { get; set; }

        [Remote("IsFlatExist", "Property", ErrorMessage = "Flat Already Exist in Building")]
        [Display(Name = "Flat No.")]
        [Required(ErrorMessage = "Please Enter a Flat No.")]
        public string FlatNo { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Property Type")]
        public int PropertyType { get; set; }

        [Display(Name = "Property Type Name")]
        public string PropertyTypeName { get; set; }

        [Display(Name = "Flat Type")]
        public int FlatTypeId { get; set; }

        [Display(Name = "Flat Type Name")]
        public string FlatTypeName { get; set; }



        public int BuildingId { get; set; }

        [Display(Name = "Building Name")]
        public string BuildingName { get; set; }


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


        //Agreement No Details
        [Display(Name = "Agreement Number")]
        public string AgreementNumber { get; set; }
        public int LesseeId { get; set; }
        public string LesseeName { get; set; }
        public string LesseeCellNo { get; set; }

        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Display(Name = "End Date")]
        public string EndDate { get; set; }

        [Display(Name = "Amount")]
        public decimal AgreementAmount { get; set; }
        public enum PT
        {
            Building,  //0
            Vellas,    //1
            Flat,      //2
            Shop       //3
        }


    }
}