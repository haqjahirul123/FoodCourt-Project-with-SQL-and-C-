using System;
using System.Linq;
using System.Runtime.Serialization;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Backend;

public class LoginBackend
{
    private readonly string _databaseName;
    public LoginBackend(string databaseName)
    {
        _databaseName = databaseName;
    }
    public User LoginCustomerUser(string username, string password)
    {
        if (username == null || password == null) throw new LoginException();

        using var ctx = new FoodRescue_DbContext(_databaseName);

        var user = ctx.Users
            .Include(u => u.PrivateInfo)
            .Include(u => u.Restaurant)
            .SingleOrDefault(u =>
                u.PrivateInfo.Email.ToLower() == username.ToLower() && u.PrivateInfo.Password == password);
        if (user == null) throw new LoginException("Username or password wrong");
        
        return user;
    }

    public User LoginRestaurantUser(string username, string password)
    {
        var user = LoginCustomerUser(username, password);
        if (user.Restaurant == null) throw new LoginException("User not connected to a restaurant");

        return user;
    }

    public User LoginAdmin(string username, string password)
    {
        var user = LoginCustomerUser(username, password);
        if (!user.PrivateInfo.IsAdmin) throw new LoginException("This user does not have admin rights");
        
        return user;
    }
}

public class LoginException : Exception
{
    public LoginException()
    {
    }

    public LoginException(string message) : base(message)
    {
    }

    
}