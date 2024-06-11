using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAPI_with_ADO.Models
{
    public class ContextDbcs
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        public List<Employee> GetEmp()
        {
            List<Employee> list = new List<Employee>();
            SqlCommand cmd = new SqlCommand("Select*from tbl_employee", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Employee
                {
                    EmployeeId = Convert.ToInt32(dr[0]),
                    Name = Convert.ToString(dr[1]),
                    MobileNo = Convert.ToString(dr[2]),
                    Gender = Convert.ToString(dr[3]),
                });
            }
            return list;
        }

        public bool Add(Employee obj)
        {

            SqlCommand cmd = new SqlCommand("insert into tbl_employee values('" + obj.Name + "','" + obj.MobileNo + "','" + obj.Gender + "')", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int Id, Employee obj)
        {
            SqlCommand cmd = new SqlCommand("update tbl_employee set EmployeeId='" + Id + "',Name='" + obj.Name + "' ,age='" + obj.MobileNo + "' ,Gender='" + obj.Gender + "'where EmployeeId='" + Id + "'", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand("delete from tbl_employee where EmployeeId='" + Id + "'", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}