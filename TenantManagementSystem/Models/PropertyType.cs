﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TenantManagementSystem.Models
{
    public class PropertyType
    {
        public int Id { get; set; }

        [Display(Name = "Property Type")]
        public string PropertyTypeDescription { get; set; }


    }
}