using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TenantManagementSystem.Models
{
    public class AdminChangePassowrd
    {
        public int Id { get; set; }
        public string Name { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter User Name")]
        //[StringLength(6, MinimumLength = 3, ErrorMessage = "User Name Should be 3 to 6 Characters Long")]
        //[Remote("IsUserNameExist", "Admin", ErrorMessage = "User Name Already Exist")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        //[StringLength(10, MinimumLength = 6, ErrorMessage = "Password Should be 6 to 10 Characters Long")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please Confirm Password")]
        //[StringLength(10, MinimumLength = 6, ErrorMessage = "Password Should be 6 to 10 Characters Long")]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string NewPassword { get; set; }

    }
}