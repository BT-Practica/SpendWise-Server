using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs;
using SpendWise_Server.Repos.Interfaces;

namespace SpendWise_Server.Business.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public void createUser(UserRegisterDTO user)
    {
        if(user == null){
            throw new NullReferenceException("User is null");
        }
        //to hash the password
        //bcrypt.net
        _userRepository.createUser(user);
    }

    public void deleteUser(int id)
    {
        if(id <= 0){
            throw new InvalidDataException("Invalid ID");
        }
        User userToDelete = _userRepository.getUserById(id);
        if(userToDelete == null){
            throw new KeyNotFoundException("User not found");
        }
        _userRepository.deleteUser(id);
    }

    public User getUserById(int id)
    {
        if(id <= 0){
            throw new InvalidDataException("Invalid ID");
        }
        var user = _userRepository.getUserById(id);
        if(user == null){
            throw new KeyNotFoundException("User not found");
        }
        return user;
    }

    public void updateUser(int id, UserDTO user)
    {
        if(id <= 0){
            throw new InvalidDataException("Invalid ID");
        }
        if(user == null){
            throw new NullReferenceException("User is null");
        }
        _userRepository.updateUser(id, user);

    }

    public User FindUserByUNameAndPass(UserLoginDTO user){
        if(user.userName == null || user.Password == null){
            throw new NullReferenceException("UserName or Password is null");
        }
        User foundUser = _userRepository.FindUserByUNameAndPass(user);
        if(user == null){
            throw new KeyNotFoundException("User not found");
        }
        return foundUser;
    }
}