using SpendWise_Server.Models.Models;
using System.ComponentModel.DataAnnotations;

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
    public ICollection<Costs> Costs { get; set; } = [];
}