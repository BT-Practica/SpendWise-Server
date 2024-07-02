using System.ComponentModel.DataAnnotations;

namespace SpendWise_Server.Models;

public class Income
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public ICollection<Incomes> Incomes { get; set; } = [];
}