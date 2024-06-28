using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.Models;

public class Costs
{
    [Key]
    public int Id {get; set;}
    [Required]
    public double Amount {get; set;}
    public string Description {get; set;}
    [Required]
    public User User {get; set;}
    [Required]
    public int UserId {get; set;}
    [Required]
    public Expense_Categories Expense_Category {get; set;}
    [Required]
    public int Expense_CategoryId {get; set;}
    [Required]
    public Currencies Currency {get; set;}
    [Required]
    public int CurrencyId {get; set;}
}