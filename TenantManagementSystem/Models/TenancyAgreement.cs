using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TenantManagementSystem.Models
{
    public class TenancyAgreement
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public int BranchId { get; set; }

        [Display(Name = "Agreement Number")]
        [Required(ErrorMessage = "Please Agreement Number")]
        [Remote("IsAgreementExist", "TenancyAgreement", ErrorMessage = "Agreement No already exist")]
        public string AgreementNumber { get; set; }

        [Display(Name = "Lessee Name")]
        [Required(ErrorMessage = "Please select Lessee")]
        public int LesseeId { get; set; }

        public string LesseeName { get; set; }

        [Display(Name = "Lessor Name")]
        [Required(ErrorMessage = "Please select Lesser")]
        public int LessorId { get; set; }

        public string LessorName { get; set; }

        //[Display(Name = "From Date")]
        //public DateTime FromDate { get; set; }

        //[Display(Name = "To Date")]
        //public DateTime ToDate { get; set; }

        [Display(Name = "Building Name")]
        [Required(ErrorMessage = "Please select Building")]
        public int BuildingId { get; set; }

        public string BuildingName { get; set; }

        [Display(Name = "Flat / Shop")]
        [Required(ErrorMessage = "Please select Flat")]
        public int FlatId { get; set; }

        public string FlatNo { get; set; }
        public int FlatTypeId { get; set; }

        public string FlatType { get; set; }


        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public string StartDateDetail { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public string EndDateDetail { get; set; }


        [Display(Name = "Rent Duration in Days")]
        public int RentDurationinDays { get; set; }
        //public string CardNumber { get; set; }

        [Display(Name = "Rent Duration In Months")]
        public int RentDurationinMonths { get; set; }

        [Display(Name = "Monthly Amount")]
        public decimal MonthlyAmount { get; set; }

        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsStarted { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }


    }
}