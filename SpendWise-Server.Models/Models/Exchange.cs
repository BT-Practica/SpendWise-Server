using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.Models;

public class Exchange
{
    [Key]
    public int Id {get; set;}
    [Required]
    public double Amount {get; set;}
    [Required]
    public int CurrencyId {get; set;}
    [Required]
    public Currencies FirstCurrency {get; set;}
    [Required]
    public int SecondCurrencyId {get; set;}
    [Required]
    public Currencies SecondCurrency {get; set;} 
}