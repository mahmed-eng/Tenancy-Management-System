using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TenantManagementSystem.Gateway;
using TenantManagementSystem.Models;

namespace TenantManagementSystem.BLL
{
    public class LesseeLessorManager
    {
        LesseeLessorGateway aLesseeLessorGateway = new LesseeLessorGateway();
        string successMessage = string.Empty;

        public string Save(LesseeLessor aLesseeLessor)
        {
            try
            {
                if (aLesseeLessorGateway.Save(aLesseeLessor) > 0)
                {
                    successMessage = "Save Successfully!";
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

        //Update
        public string UPDATE(LesseeLessor aLesseeLessor)
        {
            try
            {
                if (aLesseeLessorGateway.Update(aLesseeLessor) > 0)
                {
                    successMessage = "Save Successfully!";
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


        //Delete
        public string DELETE(LesseeLessor aLesseeLessor)
        {
            try
            {
                if (aLesseeLessorGateway.Delete(aLesseeLessor) > 0)
                {
                    successMessage = "Delete Successfully!";
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

        public string Update(LesseeLessor aLesseeLessor)
        {
            try
            {
                if (aLesseeLessorGateway.Update(aLesseeLessor) > 0)
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


        //View
        //public string DELETE(LesseeLessor aLesseeLessor)
        //{
        //    if (aLesseeLessorGateway.Delete(aLesseeLessor) > 0)
        //    {
        //        return "Delete Successfully!";
        //    }
        //    else
        //    {
        //        return "Failed";
        //    }
        //}



        public List<LesseeLessor> GetAllLesseeLessor()
        {
            return aLesseeLessorGateway.GetAllLesseeLessor();
        }
        public LesseeLessor GetLesseeLessorById(int LesseeLessorId)
        {
            var LesseeLessors = GetAllLesseeLessor();
            LesseeLessor LesseeLessor = LesseeLessors.FirstOrDefault(t => t.Id == LesseeLessorId);
            return LesseeLessor;
        }

    }
}