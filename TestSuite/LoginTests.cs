using System.Linq;
using DataLayer.Backend;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TestSuite;

public class LoginTests
{
    private const string DatabaseName = "FoodRescue_ProjectDatabase_TEST";
    private readonly LoginBackend _loginBackend;
    public LoginTests()
    {
        _loginBackend = new LoginBackend(DatabaseName);

        using var ctx = new FoodRescue_DbContext(DatabaseName);
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();
        ctx.Seed();
    }

    [Fact]
    public void LoginCostumerUserTest()
    {
        using var ctx = new FoodRescue_DbContext(DatabaseName);

        var userRecord = ctx.Users
            .Include(u => u.PrivateInfo)
            .Single(u =>
                u.PrivateInfo.Email == "Kim.bjornsen@hotmail.com" && u.PrivateInfo.Password == "Password1");

        var user = _loginBackend.LoginCustomerUser("Kim.bjornsen@hotmail.com", "Password1");

        Assert.NotNull(userRecord);
        Assert.NotNull(user);
        Assert.Null(user.Restaurant);
        Assert.Equal(userRecord.PrivateInfo.Email, user.PrivateInfo.Email);
        Assert.Equal(userRecord.PrivateInfo.Password, user.PrivateInfo.Password);
        Assert.Equal(userRecord.PrivateInfo.FullName, user.PrivateInfo.FullName);
        Assert.Equal(userRecord.PrivateInfo.UserId, user.PrivateInfo.UserId);
    }

    [Fact]
    public void LoginRestaurantUserTest()
    {
        using var ctx = new FoodRescue_DbContext(DatabaseName);

        var userRecord = ctx.Users
            .Include(u => u.PrivateInfo)
            .Include(u => u.Restaurant)
            .Single(u =>
                u.PrivateInfo.Email == "Server@Mcdonalds.com" && u.PrivateInfo.Password == "Password1MCD");

        var user = _loginBackend.LoginRestaurantUser("Server@Mcdonalds.com", "Password1MCD");

        Assert.NotNull(userRecord);
        Assert.NotNull(user);
        Assert.Equal(userRecord.PrivateInfo.Email, user.PrivateInfo.Email);
        Assert.Equal(userRecord.PrivateInfo.Password, user.PrivateInfo.Password);
        Assert.Equal(userRecord.Restaurant.RestaurantId, user.Restaurant.RestaurantId);
        Assert.Equal(userRecord.PrivateInfo.UserId, user.PrivateInfo.UserId);
    }

    [Theory]
    [InlineData("NotExisting@yahoo.se", "Password1M")]
    [InlineData("Kim.bjornsen@hotmail.com", "Password1")]
    [InlineData("Server@Mcdonalds.com", "Password1")]
    [InlineData(null, null)]

    public void LoginRestaurantUserNotCorrectTest(string username, string password)
    {
        Assert.Throws<LoginException>(() => _loginBackend.LoginRestaurantUser(username, password));
    }

    [Fact]
    public void LoginAdminUserCorrectTest()
    {
        using var ctx = new FoodRescue_DbContext(DatabaseName);

        var userRecord = ctx.Users
            .Include(u => u.PrivateInfo)
            .Include(u => u.Restaurant)
            .Single(u =>
                u.PrivateInfo.Email == "admin@foodrescue.com" && u.PrivateInfo.Password == "Adminpassword1");

        var user = _loginBackend.LoginAdmin("admin@foodrescue.com", "Adminpassword1");

        Assert.NotNull(userRecord);
        Assert.NotNull(user);
        Assert.Equal(userRecord.PrivateInfo.Email, user.PrivateInfo.Email);
        Assert.Equal(userRecord.PrivateInfo.Password, user.PrivateInfo.Password);
        Assert.Equal(userRecord.PrivateInfo.UserId, user.PrivateInfo.UserId);
    }

    [Theory]
    [InlineData("NotExisting@yahoo.se", "Password1M")]
    [InlineData("Kim.bjornsen@hotmail.com", "Password1")]
    [InlineData("Server@Mcdonalds.com", "Password1")]
    [InlineData("admin@foodrescue.com", "Password1")]
    [InlineData(null, null)]

    public void LoginAdminUserNotCorrectTest(string username, string password)
    {
        Assert.Throws<LoginException>(() => _loginBackend.LoginAdmin(username, password));
    }
}