using System.ComponentModel.DataAnnotations;
using Application.DAOInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace WebAPI.Services;

public class AuthService : IAuthService
{

    private readonly UserLoginDto userLogicDto;
    private readonly IUserDAO userDao;

    public AuthService(IUserDAO userDao)
    {
        this.userDao = userDao;
    }

    private readonly HttpClient client = new();
    
    private readonly IList<User> users = new List<User>
    {
        new User
        {
            Password = "onetwo3FOUR",
            UserName = "trmo",
        },

    };

    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = await userDao.GetByUsernameAsync(username);
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }

    public async Task<User> RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }

        // Do more user info validation here
        
        // save to persistence instead of list

        await userDao.CreateAsync(user);

        return user;
    }
    
    
    
}