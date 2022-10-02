using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TenantManagementSystem.Models
{
    public class Branch
    {

        public int BranchId { get; set; }
        public int CompanyId { get; set; }
        [Display(Name = "BranchName")]

        [Required(ErrorMessage = "Please Enter Branch Name")]
        public string Name { get; set; }


        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please Insert Address")]
        public string Address { get; set; }


        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Student Email is Not Valid")]
        [Remote("IsEmailExist", "Branch", ErrorMessage = "Email Already Exist")]
        public string Email { get; set; }

        [Display(Name = "Contact No.")]
        [Required(ErrorMessage = "Please Enter Phone No")]
        // [RegularExpression(@"\+?(88)?0?1[56789][0-9]{8}\b", ErrorMessage = "Contact No is Not Valid")]
        public string Phone { get; set; }

        [Display(Name = "Fax No.")]
        public string Fax { get; set; }



        [Display(Name = "Cell No.")]
        [Required(ErrorMessage = "Please Enter Cell No")]
        public string Cell { get; set; }


        [Display(Name = "Register No.")]
        [Required(ErrorMessage = "Please Enter Register No")]

        public string RegisterNumber { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}