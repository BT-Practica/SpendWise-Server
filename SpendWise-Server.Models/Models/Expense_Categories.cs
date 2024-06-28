using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.Models;

public class Expense_Categories
{
    [Key]
    public int Id {get; set;}
    [Required]
    [MaxLength(75)]
    public string Name {get; set;}
    public ICollection<User_Categories> User_Categories{get; set;} = [];
    public ICollection<Costs> Costs {get; set;} = [];
}