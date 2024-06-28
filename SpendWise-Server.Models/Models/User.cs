using Microsoft.EntityFrameworkCore;
using SpendWise_Server.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace SpendWise_Server.Models;

[Index(nameof(UserName), nameof(Email), IsUnique = true)]
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
    public ICollection<Incomes> Incomes { get; set; } = [];
    [Required]
    public Currencies? Currency { get; set; }
    [Required]
    public int CurrencyId { get; set; }
    public ICollection<User_Categories> User_Categories { get; set; } = [];
    public ICollection<Costs> Costs {get; set;} = [];
}
