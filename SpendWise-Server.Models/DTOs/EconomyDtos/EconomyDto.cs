using System.ComponentModel.DataAnnotations;

namespace SpendWise_Server.Models.DTOs.EconomyDtos;

public class EconomyDto
{
    [Required]
    public double Amount { get; set; }
    public int UserId {get; set;}
}