﻿using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class UserLogic:IUserLogic
{
    private readonly IUserDAO userDao;

    public UserLogic(IUserDAO userDao)
    {
        this.userDao = userDao;
    }
    
    public async Task<User> CreateAsync(UserCreationDTO dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User
        {
            UserName = dto.UserName,
            Password = dto.Password
        };
    
        User created = await userDao.CreateAsync(toCreate);
    
        return created;
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParameterDTO searchParameters)
    {
        return userDao.GetAsync(searchParameters);
    }
    
    private static void ValidateData(UserCreationDTO userToCreate)
    {
        string userName = userToCreate.UserName;
        string password = userToCreate.Password;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
        if (password.Length < 3)
            throw new Exception("Password must be at least 3 characters!");
    }
}