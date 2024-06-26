using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models;

public class Currencies
{
    [Key]
    public int Id { get; set; }
    [Required]
    public char Symbol {get; set;}
    [Required]
    public string? Name {get; set;}
    public ICollection<User> Users {get; set;} = [];
    
}