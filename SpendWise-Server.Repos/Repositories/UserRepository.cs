using Microsoft.EntityFrameworkCore;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs;
using SpendWise_Server.Repos.DataLayer;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Repos.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    public UserRepository(DataContext context)
    {
        _context = context;
    }
    public void createUser(UserRegisterDTO user)
    {
        if (_context.Users.FirstOrDefault(u => u.UserName == user.username) != null)
        {
            throw new ArgumentException("Username already exists");
        }
        User newUser = new User()
        {
            UserName = user.username,
            Password = user.password,
            Email = user.email,
            CreatedDate = DateTime.Now,
            CurrencyId = user.CurrencyId//to think : default currency
        };
        _context.Users.Add(newUser);
        _context.SaveChanges();
    }

    public void deleteUser(int id)
    {
        User userToDelete = _context.Users.FirstOrDefault(u => u.Id == id);
        _context.Users.Remove(userToDelete);
        _context.SaveChanges();
    }

    public async Task<User> getUserById(int id)
    {
        User userToGet = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        return userToGet;
    }

    public void updateUser(int id, UserDTO user)//?? daca vrem sa schimbam doar parola, email-ul, sau economia
    {
        User userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id);
        userToUpdate.UserName = user.userName ?? userToUpdate.UserName;
        userToUpdate.Email = user.Email ?? userToUpdate.Email;
        userToUpdate.Password = user.Password ?? userToUpdate.Password;
        userToUpdate.CurrencyId = user.CurrencyId ?? userToUpdate.CurrencyId;
        _context.SaveChanges();
    }

    public void UpdatePassword(int id, string password)
    {
        User userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id);
        userToUpdate.Password = password;
        _context.SaveChanges();
    }
    public void UpdateEmail(int id, string email)
    {
        User userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id);
        userToUpdate.Email = email;
        _context.SaveChanges();
    }
    public async Task UpdateCurrency(int id, int CurrencyId)
    {
        User userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        userToUpdate.CurrencyId = CurrencyId;
        _context.SaveChanges();
    }

    public User FindUserByUNameAndPass(UserLoginDTO user)
    {
        User foundUser = _context.Users.FirstOrDefault(u => u.UserName == user.userName && u.Password == user.Password);
        return foundUser;
    }

    public User FindUserByUName(string userName)
    {
        User foundUser = _context.Users.FirstOrDefault(u => u.UserName == userName);
        return foundUser;
    }
    public User FindUserByEmail(string email)
    {
        User foundUser = _context.Users.FirstOrDefault(u => u.Email == email);
        return foundUser;
    }
}