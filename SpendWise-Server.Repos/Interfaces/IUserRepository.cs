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
    }
}