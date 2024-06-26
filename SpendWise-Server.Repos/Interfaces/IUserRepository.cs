using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs;

namespace SpendWise_Server.Repos.Interfaces
{
    public interface IUserRepository
    {
        public User getUserById(int id);
        public User createUser(User user);
        public User updateUser(int id, UserDTO user);
        public User deleteUser(int id);

    }
}