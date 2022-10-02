using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenantManagementSystem.Gateway;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.BLL
{
    public class AgentManager
    {
        AgentGateway aAgentGateway = new AgentGateway();
        string successMessage = string.Empty;


        public string Save(Agent aAgent)
        {
            try
            {
                if (aAgentGateway.Save(aAgent) > 0)
                {
                    successMessage = "Save Successfully!!";
                }
                else
                {
                    successMessage = "Failed";
                }
            }
            catch (Exception ex)
            {
                successMessage = "Failed " + ex.Message + " " + ex.InnerException;
            }
            return successMessage;
        }

        public string Update(Agent aAgent)
        {
            try
            {
                if (aAgentGateway.Update(aAgent) > 0)
                {
                    successMessage = "Agent Save Successfully!!";
                }
                else
                {
                    successMessage = "Failed";
                }
            }
            catch (Exception ex)
            {
                successMessage = "Failed " + ex.Message + " " + ex.InnerException;
            }
            return successMessage;
        }


        public List<Agent> GetAllAgent()
        {
            return aAgentGateway.GetAllAgent();
        }
        public Agent GetAgentById(int AgentId)
        {
            var agents = GetAllAgent();
            Agent agent = agents.FirstOrDefault(t => t.Id == AgentId);
            return agent;
        }

    }
}