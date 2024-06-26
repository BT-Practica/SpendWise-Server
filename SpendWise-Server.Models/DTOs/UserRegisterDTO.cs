using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.DTOs;

public class UserRegisterDTO
{
    // [Required]
    // public string? username {get; set;}
    [Required]
    [MinLength(8)]
    [RegularExpression("(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W])[A-Za-z\\d\\W]")]
    public string? password {get; set;}
    // [Required]
    // [EmailAddress]
    // public string? email {get; set;}
}