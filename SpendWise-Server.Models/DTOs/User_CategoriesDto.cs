using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.DTOs
{
    public class User_CategoriesDto
    {
        [Required]
        public int ExpenseCategoryId{get; set;}
        [Required]
        public int UserId {get; set;}
        [Required]
        public int Budget{get;set;}
    }
}