using System;
using System.Collections.Generic;
using DataLayer.Backend;
using DataLayer.Data;
using DataLayer.Model;
using Xunit;

namespace TestSuite
{
    public class RestaurantTests
    {
        /*Restaurant tests below*/

        private const string DataBaseTesting = "FoodRescue_ProjectDatabase_TEST";

        [Fact]
        void CheckExceptionsFoodBoxes()
        {
            using var ctx = new FoodRescue_DbContext(DataBaseTesting);
            var restaurant = new RestaurantBackend(1, databaseName: DataBaseTesting);

            List<FoodBox> f;

            Assert.ThrowsAny<Exception>(() => f = restaurant.GetAllFoodBoxes());
            Assert.ThrowsAny<Exception>(() => f = restaurant.GetSoldFoodBoxes());
            Assert.ThrowsAny<Exception>(() => f = restaurant.GetUnsoldFoodBoxes());
        }
    }
}