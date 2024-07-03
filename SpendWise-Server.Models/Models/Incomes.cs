using System.ComponentModel.DataAnnotations;

namespace SpendWise_Server.Models;

public class Incomes
{
    [Key]
    public int Id { get; set; }
    public DateTime? RegistrationDate { get; set; }
    [Required]
    public int Amount {get; set;} 
    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    public bool Reccurence { get; set; }
    [Required]
    public User User { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public Income_Categories Income_Category { get; set; }
    [Required]
    public int Income_CategoryId { get; set; }
}