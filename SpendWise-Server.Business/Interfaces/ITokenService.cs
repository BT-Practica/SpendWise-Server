using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendWise_Server.Repos.Interfaces;

public interface ITokenService
{
    string CreateToken(string username);
}