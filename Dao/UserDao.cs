using System;    
using System.Collections.Generic;    
using System.Data;    
using System.Data.SqlClient;    
using System.Linq;    
using System.Threading.Tasks; 
using TiSmart4.Models;  
    
namespace TiSmart4.Dao    
{    
    public class UserDao  
    {    
        string connectionString = "Data Source=localhost;Initial Catalog=TiSmart;User ID=sa;Password=P@55w0rd;Connect Timeout=30";    
    
        //To View all user details      
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
    
        //To Add new user record      
        public void AddUser(User user)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("master.sp_ins_user", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@vcLogin", user.vcLogin);    
                cmd.Parameters.AddWithValue("@vcPassword", user.vcPassword);    
                cmd.Parameters.AddWithValue("@vcEmail", user.vcEmail);    
                cmd.Parameters.AddWithValue("@vcName", user.vcName);  
                 cmd.Parameters.AddWithValue("@vcLastName", user.vcLastName);      
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    
        //Get the details of a particular user    
        public User GetUserData(int? biIdUser)    
        {    
            User user = new User();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                string sqlQuery = "SELECT * FROM security.user WHERE biIdUser= " + biIdUser;    
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    user.biIdUser = Convert.ToInt32(rdr["biIdUser"]);    
                    user.vcLogin = rdr["vcLogin"].ToString();    
                    user.vcEmail = rdr["vcEmail"].ToString();    
                    user.vcName = rdr["vcName"].ToString();    
                    user.vcLastName = rdr["vcLastName"].ToString();    
                    user.iIdEstatus = Convert.ToInt32(rdr["iIdEstatus"].ToString());  
                }    
            }    
            return user;    
        }    
    
        //get login User   
        public User GetLogin(Login login)    
        {    
            User user = new User();
            
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("security.sp_login", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@vcLogin", login.vcLogin);    
                cmd.Parameters.AddWithValue("@vcPassword", login.vcPassword);  

                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();     

                if (rdr.HasRows){
                    while (rdr.Read())    
                    {    
                        user.biIdUser = Convert.ToInt32(rdr["biIdUser"]);     
                        user.vcEmail = rdr["vcEmail"].ToString();    
                        user.vcName = rdr["vcName"].ToString();    
                        user.vcLastName = rdr["vcLastName"].ToString();    
                        user.iIdEstatus = Convert.ToInt32(rdr["iIdEstatus"].ToString());  
                    }   
                } 
                else{
                    user=null;
                }
            }    
            
            return user;
                 
        }    
            
    }    
}