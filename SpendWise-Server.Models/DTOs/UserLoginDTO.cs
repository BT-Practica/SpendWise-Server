using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.DTOs
{
    public class UserLoginDTO
    {
    
    [Required]
    public string userName {get; set;}
    [Required]
    public string Password {get; set;}
    }
}