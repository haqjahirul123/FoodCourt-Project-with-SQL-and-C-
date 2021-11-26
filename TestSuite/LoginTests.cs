using System.Linq;
using DataLayer.Backend;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TestSuite
{
    public class LoginTests
    {
        /*LoginManager tests below*/
        public LoginTests()
        {
            using var ctx = new FoodRescue_DbContext();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            ctx.Seed();
        }
        [Fact]
        public void LoginTest()
        {
            using var ctx = new FoodRescue_DbContext();

            var userRecord = ctx.Users
                .Include(u => u.PrivateInfo)
                .Single(u =>
                    u.PrivateInfo.Email == "Kim.bjornsen@hotmail.com" 
                    && u.PrivateInfo.Password == "Password1");

            var loginBackend = new LoginBackend();
            var user = loginBackend.Login("Kim.bjornsen@hotmail.com", "Password1");

            Assert.NotNull(userRecord);
            Assert.NotNull(user);
            Assert.Equal(userRecord.PrivateInfo.Email, user.PrivateInfo.Email);
            Assert.Equal(userRecord.PrivateInfo.Password, user.PrivateInfo.Password);
            Assert.Equal(userRecord.PrivateInfo.FullName, user.PrivateInfo.FullName);
            Assert.Equal(userRecord.PrivateInfo.UserId, user.PrivateInfo.UserId);
        }
    }
}