using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using TiSmart4.Models;
using TiSmart4.Dao;
  
namespace TiSmart4.Controllers  
{  
    [Route("api/[controller]")]
    [ApiController]    public class UserController : ControllerBase 
    {  
        UserDao objuser = new UserDao();  

        // POST api/values
        [HttpPost]
        public IActionResult Login([FromBody]Login login)  
        {  
            if (login == null)  
                return BadRequest();  
    
            try{
                
                objuser.GetLogin(login);   
                return Ok(login);
            }
            catch (Exception e)
            {   

                return BadRequest(e);
            }
        } 

    }
}