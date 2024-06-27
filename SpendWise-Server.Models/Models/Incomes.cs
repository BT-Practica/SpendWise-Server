using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models;

public class Incomes
{
    [Key]
    public int Id { get; set;}
    [Required]
    public DateTime RegistrationDate { get; set; }
    [MaxLength(200)]
    public string Description {get; set;}
    [Required]
    public bool Reccurence {get; set;}
    [Required]
    public User User {get; set;}
    public int UserId {get; set;}
    [Required]
    public Income_Categories Income_Category {get; set;}
    [Required]
    public int Income_CategoryId {get; set;}
}