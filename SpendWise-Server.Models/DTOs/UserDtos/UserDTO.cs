using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.DTOs;

public class UserDTO
{
    public string? userName {get; set;}
    [MinLength(8)]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$")]
    public string? Password {get; set;}
    [EmailAddress]
    public string? Email {get; set;}
    public int? CurrencyId { get; set; }
}