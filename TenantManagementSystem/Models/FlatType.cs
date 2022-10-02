using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TenantManagementSystem.Models
{
    public class FlatType
    {
        public int Id { get; set; }

        [Display(Name = "Flat Type")]
        public string FlatTypeDescription { get; set; }


    }
}