using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpendWise_Server.Models.Models;

namespace SpendWise_Server.Repos.Interfaces;

public interface IExchangeRepository
{
public Exchange GetExchangeById(int id);
public IEnumerable<Exchange> GetExchangeByUserId(int userId);
    
}