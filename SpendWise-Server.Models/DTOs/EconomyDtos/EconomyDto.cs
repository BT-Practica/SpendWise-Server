using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.DTOs.EconomyDtos;

public class EconomyDto
{
    [Required]
    public double Amount {get; set;}
}