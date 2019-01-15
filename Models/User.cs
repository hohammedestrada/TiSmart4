using System;    
using System.Collections.Generic;    
using System.ComponentModel.DataAnnotations;    
using System.Linq;    
using System.Threading.Tasks;    
    
namespace TiSmart4.Models    
{    
    public class User    
    {    
        public int biIdUser { get; set; }    
        [Required]    
        public string vcLogin { get; set; }    
        [Required]    
        public string vcPassword { get; set; }    
        public string vcEmail { get; set; }    
        public string vcName { get; set; } 
        public string vcLastName { get; set; } 
        public int iIdEstatus {get; set;}   
    }    
}