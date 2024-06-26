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
    UserRepository(DataContext context){
        _context = context;
    }
    public User createUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return _context.Users.FirstOrDefault(u => u.Id == user.Id);
    }

    public User deleteUser(int id)
    {
        User userToDelete = _context.Users.FirstOrDefault(u => u.Id == id);
        _context.Users.Remove(userToDelete);
        _context.SaveChanges();
        return userToDelete;
    }

    public User getUserById(int id)
    {
        User userToGet = _context.Users.FirstOrDefault(u => u.Id == id);
        return userToGet;
    }

    public User updateUser(int id, UserDTO user)
    {
        throw new NotImplementedException();
    }
}