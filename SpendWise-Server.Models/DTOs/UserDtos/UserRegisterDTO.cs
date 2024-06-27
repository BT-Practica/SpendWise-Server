using System.ComponentModel.DataAnnotations;

namespace SpendWise_Server.Models.DTOs;

public class UserRegisterDTO
{
    [Required]
    public string? username { get; set; }
    [Required]
    [MinLength(8)]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$")]
    public string? password { get; set; }
    [Required]
    [EmailAddress]
    public string? email { get; set; }
    [Required]
    public int CurrencyId { get; set; }
}