using System;
using System.Linq;
using System.Runtime.Serialization;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Backend;

public class LoginBackend
{
    public User Login(string username, string password)
    {
        using var ctx = new FoodRescue_DbContext();

        var user = ctx.Users
            .Include(u => u.PrivateInfo)
            .Include(u => u.Restaurant)
            .SingleOrDefault(u =>
                u.PrivateInfo.Email == username && u.PrivateInfo.Password == password);
        if (user == null) throw new LoginException();
        
        return user;
    }
}

internal class LoginException : Exception
{
    public LoginException()
    {
    }

    public LoginException(string message) : base(message)
    {
    }

    
}