using System;    
using System.Collections.Generic;    
using System.ComponentModel.DataAnnotations;    
using System.Linq;    
using System.Threading.Tasks;    
    
namespace TiSmart4.Models    
{    
    public class Session    
    {    
        public int biIdSession { get; set; }    

         public int biIdUser { get; set; }  
        [Required]    
        public string vcToken { get; set; }    
        [Required]    
        public DateTime dtInicio { get; set; }    
        
        public int iIdEstatus {get; set;}   
    }    
}