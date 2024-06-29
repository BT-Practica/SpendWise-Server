using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.DTOs.ExpensesDtos
{
    public class CreateExpenseDTO
    {
        public double Amount {get; set;}
        public string Description {get; set;}
        public int UserId {get; set;}
        public int Expense_CategoryId {get; set;}
        public int CurrencyId { get; set; }
    }
}