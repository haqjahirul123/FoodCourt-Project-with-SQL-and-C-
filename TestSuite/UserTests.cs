using DataLayer.Backend;
using DataLayer.Data;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;


namespace TestSuite
{
    public class UserTests
    {

        private const string DatabaseName = "FoodRescue_ProjectDatabase_TEST";
        //private  LoginBackend _loginBackend;

   

        [Fact]
        public void TestUnsoldFoodboxes()
        {
            AdminBackend adminBackend = new AdminBackend(DatabaseName);
            UserBackend userBackend = new UserBackend(1,DatabaseName);

            adminBackend.CreateAndSeedDb();

            List<FoodBox> test = userBackend.GetUnsoldFoodBoxes("Kött");

            Assert.Null(test[0].Purchase);
            Assert.Null(test[1].Purchase);
            Assert.Null(test[2].Purchase);
            Assert.Null(test[3].Purchase);

            //List<FoodBox> meatTest = userBackend.ListUnsoldFoodBoxesOnType("Meat");

            Assert.Equal("Cheese Burger", test[0].FoodName);
        }


    }
}