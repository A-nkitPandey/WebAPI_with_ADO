using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI_with_ADO.Models;

namespace WebAPI_with_ADO.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees

        [HttpGet]

        [ActionName("GetEmployeeByID")]
        public Employee Get1(int id)
        {
            //return listEmp.First(e => e.ID == id);  
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=ITBD-NOI-LP65\\SQLEXPRESS; Initial Catalog=Testing;User ID=sa;Password=Itbd@2024";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from tbl_Employee where EmployeeId=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Employee emp = null;
            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(reader.GetValue(0));
                emp.Name = reader.GetValue(1).ToString();
                emp.MobileNo = reader.GetValue(2).ToString();
                emp.Gender = reader.GetValue(3).ToString();
            }
            myConnection.Close();
            return emp;
        }

        [HttpPost]
        public void AddEmployee(Employee employee)
        {
            //int maxId = listEmp.Max(e => e.ID);  
            //employee.ID = maxId + 1;  
            //listEmp.Add(employee);  


            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=ITBD-NOI-LP65\\SQLEXPRESS; Initial Catalog=Testing;User ID=sa;Password=Itbd@2024";
            //SqlCommand sqlCmd = new SqlCommand("INSERT INTO tblEmployee (EmployeeId,Name,ManagerId) Values (@EmployeeId,@Name,@ManagerId)", myConnection);  
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO tbl_Employee (EmployeeId,Name,MobileNo,Gender) Values (@EmployeeId,@Name,@MobileNo,@Gender)";
            sqlCmd.Connection = myConnection;


            sqlCmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            sqlCmd.Parameters.AddWithValue("@Name", employee.Name);
            sqlCmd.Parameters.AddWithValue("@MobileNo", employee.MobileNo);
            sqlCmd.Parameters.AddWithValue("@Gender", employee.Gender);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}