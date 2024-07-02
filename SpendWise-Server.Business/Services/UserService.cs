using SpendWise_Server.Business.Interfaces;
using SpendWise_Server.Models;
using SpendWise_Server.Models.DTOs;
using SpendWise_Server.Repos.Interfaces;
using System.Text.RegularExpressions;

namespace SpendWise_Server.Business.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ICurrencyRepository _currencyRepository;

    public UserService(IUserRepository userRepository, ICurrencyRepository currencyRepository)
    {
        _userRepository = userRepository;
        _currencyRepository = currencyRepository;
    }
    public void createUser(UserRegisterDTO user)
    {
        if (user == null)
        {
            throw new NullReferenceException("User is null");
        }
        //to hash the password
        user.password = BCrypt.Net.BCrypt.HashPassword(user.password);

        // string hashpass = BCrypt.Net.BCrypt.HashPassword(user.password); 
        // UserRegisterDTO newUser = new UserRegisterDTO(user.email, user...,, hashpass);    
        _userRepository.createUser(user);
    }

    public async Task deleteUser(int id)
    {
        if (id <= 0 || _userRepository.getUserById(id) == null)
        {
            throw new InvalidDataException("Invalid ID");
        }
        User userToDelete = await _userRepository.getUserById(id);
        if (userToDelete == null)
        {
            throw new KeyNotFoundException("User not found");
        }
        _userRepository.deleteUser(id);
    }

    public async Task<User> getUserById(int id)
    {
        if (id <= 0)
        {
            throw new InvalidDataException("Invalid ID");
        }
        User user = await _userRepository.getUserById(id);
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

    public void UpdatePassword(int id, string password)
    {
        if (id <= 0 || _userRepository.getUserById(id) == null)
        {
            throw new InvalidDataException("Invalid ID");
        }
        if (!Regex.IsMatch(password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$"))
        {
            throw new InvalidDataException("Invalid password");
        }
        password = BCrypt.Net.BCrypt.HashPassword(password);
        _userRepository.UpdatePassword(id, password);
    }
    public void UpdateEmail(int id, string email)
    {
        if (id <= 0 || _userRepository.getUserById(id) == null)
        {
            throw new InvalidDataException("Invalid ID");
        }
        if (!Regex.IsMatch(email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
        {
            throw new InvalidDataException("Invalid Email");
        }
        _userRepository.UpdateEmail(id, email);

    }

    public void ForgotPassword(string email, string newPassword)
    {
        User foundUser = _userRepository.FindUserByEmail(email);
        if (foundUser == null)
        {
            throw new InvalidDataException("There is no user with this email");
        }

        if (!Regex.IsMatch(newPassword, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$"))
        {
            throw new InvalidDataException("Invalid password");
        }
        newPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
        _userRepository.UpdatePassword(foundUser.Id, newPassword);
    }

    public async Task UpdateCurrency(int id, int CurrencyId)
    {
        Console.WriteLine(CurrencyId);
        if (id <= 0 || await _userRepository.getUserById(id) == null)
        {
            throw new InvalidDataException("Invalid ID");
        }
        if (CurrencyId <= 0 || await _currencyRepository.GetCurrency(CurrencyId) == null)
        {//getCurrencyById and verify if null
            throw new InvalidDataException("Invalid CurrencyId");
        }
        await _userRepository.UpdateCurrency(id, CurrencyId);
    }

    public User FindUserByUNameAndPass(UserLoginDTO user)
    {
        //hash password first
        User foundUser = _userRepository.FindUserByUName(user.userName);
        if (foundUser == null)
        {
            throw new KeyNotFoundException("User not found");
        }
        bool verifiedPassword = BCrypt.Net.BCrypt.Verify(user.Password, foundUser.Password);
        if (verifiedPassword == false)
        {
            throw new InvalidDataException("Wrong password");
        }
        return foundUser;
    }
}