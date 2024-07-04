using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.DTOs.IncomesDtos
{
    public class CreateIncomeDto
    {
    [Required]
    public int Amount {get; set;} 
    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    public bool Reccurence { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public string Income_CategoryName {get; set;}
    }
}