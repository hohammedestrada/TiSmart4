using System;    
using System.Collections.Generic;    
using System.ComponentModel.DataAnnotations;    
using System.Linq;    
using System.Threading.Tasks;    
    
namespace TiSmart4.Models    
{    
    public class Employee    
    {    
        public int biIdEmployee { get; set; }    
        [Required]    
        public string vcName { get; set; }    
        [Required]    
        public string vcGender { get; set; }    
        [Required]    
        public string vcDepartment { get; set; }    
        [Required]    
        public string vcCity { get; set; } 

        public int iIdEstatus {get; set;}   
    }    
}