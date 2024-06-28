using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
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
        if (user == null)
        {
            throw new NullReferenceException("User is null");
        }
        //to hash the password
        user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
        _userRepository.createUser(user);
    }

    public void deleteUser(int id)
    {
        if (id <= 0)
        {
            throw new InvalidDataException("Invalid ID");
        }
        User userToDelete = _userRepository.getUserById(id);
        if (userToDelete == null)
        {
            throw new KeyNotFoundException("User not found");
        }
        _userRepository.deleteUser(id);
    }

    public User getUserById(int id)
    {
        if (id <= 0)
        {
            throw new InvalidDataException("Invalid ID");
        }
        var user = _userRepository.getUserById(id);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }
        return user;
    }

    public void updateUser(int id, UserDTO user)
    {
        if (id <= 0)
        {
            throw new InvalidDataException("Invalid ID");
        }
        if (user == null)
        {
            throw new NullReferenceException("User is null");
        }
        //hash password
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        _userRepository.updateUser(id, user);

    }

    public void UpdatePassword(int id, string password){
        if(id <= 0 || _userRepository.getUserById(id) == null){
            throw new InvalidDataException("Invalid ID");
        }
        if(Regex.IsMatch(password,"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$")){
            throw new InvalidDataException("Invalid password");
        }
        password = BCrypt.Net.BCrypt.HashPassword(password);
        _userRepository.UpdatePassword(id, password);
    }
    public void UpdateEmail(int id, [EmailAddress] string email){
        if(id <= 0 || _userRepository.getUserById(id) == null){
            throw new InvalidDataException("Invalid ID");
        }
        _userRepository.UpdateEmail(id, email);

    }
    public void UpdateCurrency(int id, int CurrencyId){
        if(id <= 0 || _userRepository.getUserById(id) == null){
            throw new InvalidDataException("Invalid ID");
        }
        if(CurrencyId <= 0){//getCurrencyById and verify if null
            _userRepository.UpdateCurrency(id, CurrencyId);
        }
    }

    public User FindUserByUNameAndPass(UserLoginDTO user){
        //hash password first
        User foundUser = _userRepository.FindUserByUName(user.userName);
        if(foundUser == null){
            throw new KeyNotFoundException("User not found");
        }
        bool verifiedPassword = BCrypt.Net.BCrypt.Verify(user.Password, foundUser.Password);
        if(verifiedPassword == false){
            throw new InvalidDataException("Wrong password");
        }
        return foundUser;
    }
}