﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;  

namespace SpendWise_Server.Models;

[Index(nameof(UserName), IsUnique=true)]
public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
    [EmailAddress]
    [MaxLength(256)]
    [Required]
    public string? Email { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    public ICollection<Economies> Economies { get; set; } = [];
    public ICollection<Incomes> Incomes {get; set;} = [];     
    [Required]
    public Currencies? Currency {get; set;}
    public int CurrencyId { get; set; }
}
