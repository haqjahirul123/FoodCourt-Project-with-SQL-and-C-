using DataLayer.Data;
using Xunit;

namespace TestSuite
{
    public class UserTests
    {

        private const string DatabaseName = "FoodRescue_ProjectDatabase_TEST";

        [Fact]

        public void CheckFoodBoxesAreExistForBuy()
        {
            using var ctx = new FoodRescue_DbContext(DatabaseName);

            var foodBoxesExist = ctx.FoodBoxes.Find(2);
            //var foodType2 = ctx.FoodBoxes
            Assert.NotNull(foodBoxesExist);
         
        }

    }
}