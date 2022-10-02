using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenantManagementSystem.Gateway;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.BLL
{
    public class NumberSequenceManager
    {
        NumberSequenceGateway aNumberSequenceGateway = new NumberSequenceGateway();
        string successMessage = string.Empty;

        public string GetNumberSequence(string module)
        {
            string numberSequence = aNumberSequenceGateway.GetNumberSequence(module);
            return numberSequence;
        }

    }
}