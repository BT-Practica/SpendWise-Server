using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.DTOs.ExpensesDtos
{
    public class RemoveExpenseDTO
    {
        [Required]
        public int ExpenseId{get;set;}
        
        [Required]
        public int UserId{get;set;}
        
    }
}