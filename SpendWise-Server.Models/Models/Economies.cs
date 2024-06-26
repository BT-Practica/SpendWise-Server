using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models;

public class Economies
{
    public int Id { get; set; }
    [Required]
    public DateTime? RegistrationDate { get; set; }
    [Required]
    //range lower than the sum of income
    public double? Amount { get; set; }
    [Required]
    public User? User {get; set;}
    public int UserId {get; set;}
}