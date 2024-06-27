using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs;
using SpendWise_Server.Repos.DataLayer;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Repos.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    public UserRepository(DataContext context){
        _context = context;
    }
    public void createUser(UserRegisterDTO user)
    {

        User newUser = new User(){
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

    public User getUserById(int id)
    {
        User userToGet = _context.Users.FirstOrDefault(u => u.Id == id);
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

    public User FindUserByUNameAndPass(UserLoginDTO user){
        User foundUser = _context.Users.FirstOrDefault(u => u.UserName == user.userName && u.Password == user.Password);
        return foundUser;
    }
    
}