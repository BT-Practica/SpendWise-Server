using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.DTOs
{
    public class DeleteExpense_CategoryDto
    {
        [Required]
        public int ExpenseCategoryid{get; set;}
        [Required]
        public int UserId{get;set;}
    }
}