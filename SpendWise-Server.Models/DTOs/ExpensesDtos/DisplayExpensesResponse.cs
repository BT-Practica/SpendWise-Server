using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpendWise_Server.Models.Models;

namespace SpendWise_Server.Models.DTOs.ExpensesDtos;

public class DisplayExpensesResponse
{
    public int Id {get; set;}
    public double Amount {get; set;}
    public string Description {get; set;}
    public string Category {get; set;}
}