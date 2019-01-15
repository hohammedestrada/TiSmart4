using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using TiSmart4.Models;  
using TiSmart4.Dao;

namespace TiSmart4.Controllers

{
  [Route("api/[controller]")]
  public class TokenController : Controller
  {

    UserDao objuser = new UserDao();   
    SessionDao objsession = new SessionDao();     
    private IConfiguration _config;

    public TokenController(IConfiguration config)
    {
      _config = config;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult CreateToken([FromBody]Login login)
    {
      IActionResult response = Unauthorized();
      var user = Authenticate(login);

      if (user != null)
      {
        var tokenString = BuildToken(user);
        if (tokenString != null)
            {
              response = Ok(new { token = tokenString });
            }
      }

      return response;
    }

    private string BuildToken(User user)
    {
          var claims = new[] {
                                new Claim(JwtRegisteredClaimNames.Sub, user.vcName),
                                new Claim(JwtRegisteredClaimNames.Email, user.vcEmail),
                                //new Claim(JwtRegisteredClaimNames.Birthdate, DateTime.Now.ToString("yyyy-MM-dd")),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                             };

          var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
          var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
       
          var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                        _config["Jwt:Issuer"],
                                        claims,
                                        expires: DateTime.Now.AddMinutes(5),
                                        signingCredentials: creds
                                        );
          var writeToken=new JwtSecurityTokenHandler().WriteToken(token);

          if (writeToken !=null)
          {
              objsession.AddSession(user,writeToken,DateTime.Now.AddMinutes(5));
          }

          return writeToken;
    }
    
    private User Authenticate(Login login)
     {
        User user = null;
        user=objuser.GetLogin(login);
        return user;
     }

  
    
  }
}