using System;
using System.Collections.Generic;
using DataLayer.Backend;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.Data.SqlClient;
using Xunit;

namespace TestSuite
{
    public class AdminTests
    {
        /*Admin tests below*/
        const string testDatabase = "FoodRescue_ProjectDatabase_TEST";

        [Fact]
        void Exception_NoDatabase_Test()
        {
            using var ctx = new FoodRescue_DbContext(testDatabase);
            ctx.Database.EnsureDeleted();
            ctx.SaveChanges();

            var admin = new AdminBackend(testDatabase);

            List<User> u;
            List<Restaurant> r;

            Assert.ThrowsAny<Exception>(() => u = admin.GetUsers());
            Assert.ThrowsAny<Exception>(() => r = admin.GetRestaurants());
        }

        [Fact]
        void NotNull_DatabaseToList_Test()
        {
            using var ctx = new FoodRescue_DbContext(testDatabase);
            ctx.Database.EnsureDeleted();
            ctx.SaveChanges();

            var admin = new AdminBackend(testDatabase);

            List<User> u;
            List<Restaurant> r;
            
            admin.CreateAndSeedDb();

            u = admin.GetUsers();
            r = admin.GetRestaurants();

            Assert.NotNull(u);
            Assert.NotNull(r);
        }

        //BUG MinimumLength = 3 i Restaurant modelen tycks inte snappas upp
        //pratat med Kim som fått feedback att sql inte kan hantera minimum som han skrivit det,
        //lämnar ändå kvar då det är ett intresant test.
        [Theory]
        [InlineData("Acceptable", "12")]
        [InlineData("12", "12")]
        [InlineData("12", "Acceptable")]
        [InlineData("Acceptable", "This string has more than fourty characters")]
        [InlineData("This string has more than fourty characters", "This string has more than fourty characters")]
        [InlineData("This string has more than fourty characters", "Acceptable")]
        void Exception_AddRestaurant_Test(string n, string p)
        {
            using var ctx = new FoodRescue_DbContext(testDatabase);
            var admin = new AdminBackend(testDatabase);
            admin.CreateAndSeedDb();

            string lessThan3 = "12";
            string acceptableString = "acceptable";
            string moreThan40 = "This string has more than fourty characters";

            Assert.ThrowsAny<Exception>(() => admin.AddRestaurant(n, p));
        }
    }
}