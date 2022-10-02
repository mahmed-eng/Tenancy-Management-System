using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TenantManagementSystem.Models
{
    public class LesseeLessor
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public int BranchId { get; set; }

        [Required(ErrorMessage = "Please Enter Card Number")]
        [Display(Name = "Emirates Id")]
        public string CardNumber { get; set; }

        [Display(Name = "Name")]
        [Remote("IsNameExist", "LesseeLessor", ErrorMessage = "Name already exist")]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Display(Name = "Beneficiary Name")]
        //[Required(ErrorMessage = "Please Enter Peneficiary")]
        public string Peneficiary { get; set; }

        [Display(Name = "Profession")]
        // [Required(ErrorMessage = "Please Enter Profession")]
        public string Profession { get; set; }

        [Display(Name = "Address")]
        //[Required(ErrorMessage = "Please Insert Address")]
        public string Address { get; set; }


        [Display(Name = "Fax No.")]
        public string Fax { get; set; }


        [Display(Name = "Telephone")]
        //[Required(ErrorMessage = "Please Enter Telephone No")]
        public string Phone { get; set; }


        [Display(Name = "Cell")]
        [Required(ErrorMessage = "Please Enter Cell No")]
        public string Cell { get; set; }

        [Display(Name = "POBox")]
        //[Required(ErrorMessage = "Please Enter POBox")]
        public string POBox { get; set; }

        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Student Email is Not Valid")]
        [Remote("IsEmailExist", "Company", ErrorMessage = "Email Already Exist")]
        public string Email { get; set; }


        [Display(Name = "Number of Property Residents")]
        public int? NOPR { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int RecordType { get; set; }

        public enum RC
        {
            Default,  //0
            Lessor,   //1
            Lessee     //2
        }
    }
}