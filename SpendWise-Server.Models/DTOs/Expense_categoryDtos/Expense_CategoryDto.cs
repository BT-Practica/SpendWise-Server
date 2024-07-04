using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.DTOs;

public class Expense_CategoryDto
{
    [Required]
    public int UserId{get; set;}
    [Required]
    [MaxLength(75)]
    public string Name {get; set;}
    [Required]
    public DateTime CreatedAt{get; set;}

    
}