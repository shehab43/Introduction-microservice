using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlatFormService.Dtos
{
    public class PlatFormCreateDto
    {
     
         [Required]
        public string Name {get;set;}

        [Required]
        public string Publisher {get;set;}

        [Required]
        public  string Cost {get;set;}
    }
}