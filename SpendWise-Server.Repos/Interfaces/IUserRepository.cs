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
        public void createUser(UserRegisterDTO user);
        public void updateUser(int id, UserDTO user);
        public void deleteUser(int id);
        public User FindUserByUNameAndPass(UserLoginDTO user);
        public User FindUserByUName(string userName);
    }
}