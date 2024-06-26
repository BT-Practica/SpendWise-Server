﻿using System.ComponentModel.DataAnnotations;

namespace SpendWise_Server.Models
{
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
        public ICollection<Incomes> Incomes {get; set;} = [];     
        public ICollection<Income_Categories> Income_Categories {get; set;} = [];
        [Required]
        public Currencies? Currency {get; set;}
    }
}
