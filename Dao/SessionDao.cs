using System;    
using System.Collections.Generic;    
using System.Data;    
using System.Data.SqlClient;    
using System.Linq;    
using System.Threading.Tasks; 
using TiSmart4.Models;  
    
namespace TiSmart4.Dao    
{    
    public class SessionDao  
    {    
        string connectionString = "Data Source=localhost;Initial Catalog=TiSmart;User ID=sa;Password=P@55w0rd;Connect Timeout=30";    
   
        //To Add new user record      
        public void AddSession(User user, string vcToken, DateTime dtFin)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("security.sp_ins_session", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@biIdUser", user.biIdUser);    
                cmd.Parameters.AddWithValue("@vcToken", vcToken);    
                cmd.Parameters.AddWithValue("@dtInicio", DateTime.Now);    
                cmd.Parameters.AddWithValue("@dtFin", dtFin);     
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }    
    
        //Get the details of a particular user    
        public Session GetUserSession (int? biIdUser)    
        {    
            Session session = new Session();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("master.sp_ins_session", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@biIdUser", biIdUser);    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();  

            if (rdr.HasRows)
                {
                    while (rdr.Read())    
                    {    
                        session.biIdSession = Convert.ToInt32(rdr["biIdSession"]);  
                        session.biIdUser = Convert.ToInt32(rdr["biIdUser"]);    
                        session.vcToken = rdr["vcToken"].ToString();    
                        
                    } 
                }
            else
                {
                    session= null;
                }   

            }    
            return session;    
        }    
    
        //get login User   
        
    }    
}