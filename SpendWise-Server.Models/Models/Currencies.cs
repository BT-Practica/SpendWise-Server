using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SpendWise_Server.Models.Models;

namespace SpendWise_Server.Models;

public class Currencies
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(4)]
    public string Symbol { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    public ICollection<User> Users { get; set; } = [];
    public ICollection<Exchange> FirstExchanges { get; set; } = [];
    public ICollection<Exchange> SecondExchanges { get; set; } = [];
}