using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TenantManagementSystem.Models
{
    public class ChequeDetails
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public int BranchId { get; set; }

        public int BuildingId { get; set; }

        public int TenantAgreementId { get; set; }

        [Display(Name = "Cheque Number")]
        [Required(ErrorMessage = "Please Cheque Number")]
        public string ChequeNumber { get; set; }

        [Display(Name = "Tenant Agreement Number")]
        [Required(ErrorMessage = "Please Enter Agreement Number")]
        public string TenantAgreementNumber { get; set; }


        [Display(Name = "Amount")]
        public decimal Amount { get; set; }


        [Display(Name = "Cheque Date")]
        public DateTime ChequeDate { get; set; }

        //[Display(Name = "From Date")]
        //public DateTime FromDate { get; set; }

        //[Display(Name = "To Date")]
        //public DateTime ToDate { get; set; }

        public int LessorId { get; set; }

        [Display(Name = "Lessor Name")]
        public string LessorName { get; set; }

        public int LesseeId { get; set; }

        [Display(Name = "Lessee Name")]
        public string LesseeName { get; set; }

        public string ChequeDateDetail { get; set; }

        public int? CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        public string CreatedDateDetail { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean IsCashed { get; set; }
        public bool PaymentFromCash { get; set; }
        //public bool PendingCheque { get; set; }


    }
}