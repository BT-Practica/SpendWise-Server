using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs;

namespace SpendWise_Server.Repos.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> getUserById(int id);
        public void createUser(UserRegisterDTO user);
        public void updateUser(int id, UserDTO user);
        public void UpdatePassword(int id, string password);
        public void UpdateEmail(int id, string email);
        public Task UpdateCurrency(int id, int currencyID);
        public void deleteUser(int id);
        public User FindUserByUNameAndPass(UserLoginDTO user);
        public User FindUserByUName(string userName);
    }
}