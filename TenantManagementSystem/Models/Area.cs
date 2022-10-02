using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TenantManagementSystem.Models
{
    public class Area
    {

        public int Id { get; set; }

        public int CompanyId { get; set; }

        public int BranchId { get; set; }

        public int CityId { get; set; }

        //public int CountryId { get; set; }

        [Display(Name = "Area Name")]
        [Required(ErrorMessage = "Please Enter Area Name")]
        public string Name { get; set; }

        [Display(Name = "City Name")]
        [Required(ErrorMessage = "Please Enter City Name")]
        public string CityName { get; set; }

        //[Display(Name = "CountryName")]
        //[Required(ErrorMessage = "Please Enter Country Name")]
        //public string Country { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
        //public object Email { get; internal set; }
    }
}