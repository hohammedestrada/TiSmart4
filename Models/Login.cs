using System;    
using System.Collections.Generic;    
using System.ComponentModel.DataAnnotations;    
using System.Linq;    
using System.Threading.Tasks;   

namespace TiSmart4.Models    
{   public class Login
    {
       [Required]    
        public string vcLogin { get; set; }    
        [Required]    
        public string vcPassword { get; set; }  
    }
}