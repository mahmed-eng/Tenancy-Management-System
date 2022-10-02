using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TenantManagementSystem.Gateway
{

    public class DashboardGateway : Gateway
    {
        //public int GetTotalTeacher()
        //{
        //    Query = "SELECT COUNT(Id) FROM Teacher_tb";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    int value = (Int32)Command.ExecuteScalar();
        //    Connection.Close();
        //    return value;
        //}

        //public int GetTotalStudent()
        //{
        //    Query = "SELECT COUNT(Id) FROM Student_tb";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    int value = (Int32)Command.ExecuteScalar();
        //    Connection.Close();
        //    return value;
        //}

        //public int GetTotalDepartment()
        //{
        //    Query = "SELECT COUNT(Id) FROM Department_tb";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    int value = (Int32)Command.ExecuteScalar();
        //    Connection.Close();
        //    return value;
        //}

        //internal List<Branch> GetBranch()
        //{
        //    Query = "SELECT * FROM BRANCH_TB ORDER BY NAME";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    List<Branch> aChart = new List<Branch>();
        //    while (Reader.Read())
        //    {
        //        Branch aChartVm = new Branch()
        //        {
        //            BranchId = Convert.ToInt16(Reader["Id"]),
        //            CompanyId = Convert.ToInt16(Reader["CompanyId"]),
        //            Name = Convert.ToString(Reader["Name"])
        //        };
        //        aChart.Add(aChartVm);
        //    }
        //    Connection.Close();
        //    return aChart;
        //}

        //internal List<Company> GetCompany()
        //{
        //    Query = "SELECT * FROM COMPANY ORDER BY NAME";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    List<Company> aChart = new List<Company>();
        //    while (Reader.Read())
        //    {
        //        Company aChartVm = new Company()
        //        {
        //            CompanyId = Convert.ToInt16(Reader["CompanyId"]),
        //            Name = Convert.ToString(Reader["Name"])
        //        };
        //        aChart.Add(aChartVm);
        //    }
        //    Connection.Close();
        //    return aChart;
        //}

        //public int GetTotalRoom()
        //{
        //    Query = "SELECT COUNT(Id) FROM Room_tb";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    int value = (Int32)Command.ExecuteScalar();
        //    Connection.Close();
        //    return value;
        //}

        //public List<ChartVM> GetCount()
        //{
        //    Query = "SELECT DISTINCT Department_tb.DeptCode as Code, Department_tb.Id as Did, COUNT(Student_tb.Id) over " +
        //            "(partition by Student_tb.DeptId) as Student FROM Department_tb INNER JOIN Student_tb on " +
        //            "Department_tb.Id = Student_tb.DeptId ORDER BY Did ASC";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    List<ChartVM> aChart = new List<ChartVM>();
        //    while (Reader.Read())
        //    {
        //        ChartVM aChartVm = new ChartVM()
        //        {
        //            DeptCode = Convert.ToString(Reader["Code"]),
        //            TotalStudent = Convert.ToInt32(Reader["Student"])
        //        };
        //        aChart.Add(aChartVm);
        //    }
        //    Connection.Close();
        //    return aChart;
        //}
    }
}