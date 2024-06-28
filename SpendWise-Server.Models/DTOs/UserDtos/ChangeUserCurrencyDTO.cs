using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Models.DTOs.UserDtos
{
    public class ChangeUserCurrencyDTO
    {
        public int id {get; set;}
        public int currencyId {get; set;}
    }
}