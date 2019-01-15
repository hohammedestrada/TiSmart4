using System;    
using System.Collections.Generic;    
using System.Data;    
using System.Data.SqlClient;    
using System.Linq;    
using System.Threading.Tasks; 
using TiSmart4.Models;  
    
namespace TiSmart4.Dao    
{    
    public class EmployeeDao  
    {    
        string connectionString = "Data Source=localhost;Initial Catalog=TiSmart;User ID=sa;Password=P@55w0rd;Connect Timeout=30";    
    
        //To View all employees details      
        public IEnumerable<Employee> GetAllEmployees()    
        {    
            List<Employee> lstemployee = new List<Employee>();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("Master.sp_sel_employees", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    Employee employee = new Employee();    
    
                    employee.biIdEmployee = Convert.ToInt32(rdr["biIdEmployee"]);    
                    employee.vcName = rdr["vcName"].ToString();    
                    employee.vcGender = rdr["vcGender"].ToString();    
                    employee.vcDepartment = rdr["vcDepartment"].ToString();    
                    employee.vcCity = rdr["vcCity"].ToString();    
                    employee.iIdEstatus = Convert.ToInt32(rdr["iIdEstatus"].ToString());  
    
                    lstemployee.Add(employee);    
                }    
                con.Close();    
            }    
            return lstemployee;    
        }    
    
        //To Add new employee record      
        public void AddEmployee(Employee employee)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("master.sp_ins_employee", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@vcName", employee.vcName);    
                cmd.Parameters.AddWithValue("@vcGender", employee.vcGender);    
                cmd.Parameters.AddWithValue("@vcDepartment", employee.vcDepartment);    
                cmd.Parameters.AddWithValue("@vcCity", employee.vcCity);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    
        //To Update the records of a particluar employee    
        public void UpdateEmployee(Employee employee)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("master.sp_upd_employee", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@biIdEmployee", employee.biIdEmployee);    
                cmd.Parameters.AddWithValue("@vcName", employee.vcName);    
                cmd.Parameters.AddWithValue("@vcGender", employee.vcGender);    
                cmd.Parameters.AddWithValue("@vcDepartment", employee.vcDepartment);    
                cmd.Parameters.AddWithValue("@vcCity", employee.vcCity);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    
        //Get the details of a particular employee    
        public Employee GetEmployeeData(int? biIdEmployee)    
        {    
            Employee employee = new Employee();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                string sqlQuery = "SELECT * FROM master.employee WHERE biIdEmployee= " + biIdEmployee;    
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    employee.biIdEmployee = Convert.ToInt32(rdr["biIdEmployee"]);    
                    employee.vcName = rdr["vcName"].ToString();    
                    employee.vcGender = rdr["vcGender"].ToString();    
                    employee.vcDepartment = rdr["vcDepartment"].ToString();    
                    employee.vcCity = rdr["vcCity"].ToString();    
                    employee.iIdEstatus = Convert.ToInt32(rdr["iIdEstatus"].ToString());  
                }    
            }    
            return employee;    
        }    
    
        //To Delete the record on a particular employee    
        public void DeleteEmployee(int? biIdEmployee)    
        {    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("master.sp_del_employee", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@biIdEmployee", biIdEmployee);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    }    
}