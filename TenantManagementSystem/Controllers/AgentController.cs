using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TenantManagementSystem.BLL;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.Controllers
{
    public class AgentController : Controller
    {
        CompanyManager aCompanyManager = new CompanyManager();
        BranchManager aBranchManager = new BranchManager();
        AgentManager aAgentManager = new AgentManager();

        [HttpGet]
        public ActionResult SaveAgent()
        {
            Agent aAgent = new Agent();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();
            return View(aAgent);
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpPost]
        public ActionResult SaveAgent(Agent aAgent)
        {
            ViewBag.Company = aCompanyManager.GetAllCompany();

            ViewBag.Branch = aBranchManager.GetAllBranch();
            aAgent.CreatedBy = Convert.ToInt16(Session["Id"]);
            aAgent.CreatedDate = DateTime.Now;
            aAgent.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aAgent.BranchId = Convert.ToInt16(Session["BranchId"]);
            ViewBag.Message = aAgentManager.Save(aAgent);
            return View();
        }

        //----------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Agent aAgent = aAgentManager.GetAgentById(id);

            return View("Edit", aAgent);
        }

        [HttpPost]
        public ActionResult Edit(int id, Agent aAgent)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Agent = aAgentManager.GetAllAgent();
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aAgent.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aAgent.UpdatedDate = DateTime.Now;
            ViewBag.Message = aAgentManager.Update(aAgent);
            return View(aAgent);
        }
        //------------------------------------------------

        [HttpGet]
        public JsonResult IsEmailExist(Agent aAgent)
        {
            List<Agent> Agent = aAgentManager.GetAllAgent();
            bool isExist = Agent.FirstOrDefault(t => t.Email.ToLowerInvariant().Equals(aAgent.Email.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAgentById(Agent Agent)
        {
            var Companies = aAgentManager.GetAllAgent();
            var AgentList = Companies.Where(t => t.Id == Agent.Id).ToList();
            return Json(AgentList);
        }

        [HttpGet]
        public ActionResult ViewAgent()
        {
            List<Agent> Agent = aAgentManager.GetAllAgent();
            ViewBag.Agent = aAgentManager.GetAllAgent();
            return View(Agent);
        }

    }
}