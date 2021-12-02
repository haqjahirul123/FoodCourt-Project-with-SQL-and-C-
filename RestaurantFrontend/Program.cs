using System.Data.Common;
using DataLayer.Backend;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

MainMenu();

void MainMenu()
{
    CreateDatabase();

    #region Hela ConsoleAppen

    bool runTheProgram = true;

    while (runTheProgram)
    {
        Console.WriteLine("\n \t \t \t \t _.*¨^Welcome Waiter to your restaurant menu_.*¨^ \n \t");
        Console.Write(" #Please pick something to do \n ");
        Console.WriteLine("\t \t [1] See all sold foodpackages for a restaurant \n\t\t" +
                          " [2] See all unsold foodpackages for a restaurant \n\t\t" +
                          " [3] Add a new foodpackage for a restaurant " +
                          " [0] Leave the program");

        var menuInput = Console.ReadKey();
        int menuChoice = -1;

        try
        {
            menuChoice = int.Parse(menuInput.KeyChar.ToString());

            if (menuChoice < 0 || menuChoice > 3)
            {
                throw new Exception();
            }
            switch (menuChoice)
            {
                case 1:
                    FindAllSoldFoodPackagesForYourRestaurant();
                    ReturnToMainMenuPrompt();
                    break;

                case 2:
                   FindAllUnSoldFoodPackagesForYourRestaurant();
                    ReturnToMainMenuPrompt();
                    break;

                case 3:
                    AddNewFoodBox();
                    ReturnToMainMenuPrompt();
                    break;


                case 0:
                    runTheProgram = ExitProgramPrompt();
                    break;
            }
            Console.Clear();
        }
        catch
        {
            Console.Write("\tInvalid input, please try again");

            Console.ReadLine();
            Console.Clear();
        }


    }
}
#endregion

#region Creating database

void CreateDatabase()
{
    string databaseName = "FoodRescue_ProjectDatabase_REAL";
    var admin = new AdminBackend(databaseName);
    admin.CreateAndSeedDb();
}
#endregion

#region See all sold foodpackages for a your restaurant

void FindAllSoldFoodPackagesForYourRestaurant()
{
    string restaurantId = "FoodRescue_ProjectDatabase_REAL";
    string databaseName = "FoodRescue_ProjectDatabase_REAL";
    var restaurant = new RestaurantBackend(1, databaseName);

    restaurant.GetLoggedInRestaurantInfo();

    var soldpackages = restaurant.GetSoldFoodBoxes();

    Console.WriteLine("\t \t \t \t \n \n *All sold foodpackages for Mcdonalds* : \n");
    foreach (var s in soldpackages)
    {

        Console.WriteLine($"ID: {s.FoodboxId}, \n" +
                          $" Meal: {s.FoodName}, \n " +
                          $"Catogory: {s.TypeOfFood}, \n" +
                          $" Cost: {s.Price}, \n " +
                          $"{s.Restaurant} \n ");
    }

}
Console.Clear();

#endregion

#region See all unsold foodpackages for your restaurant

void FindAllUnSoldFoodPackagesForYourRestaurant()
{
    string restaurantId = "FoodRescue_ProjectDatabase_REAL";
    string databaseName = "FoodRescue_ProjectDatabase_REAL";
    var restaurant = new RestaurantBackend(1, databaseName);
   

    restaurant.GetLoggedInRestaurantInfo();

    var unsoldFoodboxes = restaurant.GetUnsoldFoodBoxes();
    Console.WriteLine("\t \t \t \t \n \n *All unsold foodpackages for Mcdonalds* : \n  ");

    foreach (var f in unsoldFoodboxes)
    {
        Console.WriteLine($"ID: {f.FoodboxId}, \n" +
                          $" Meal: {f.FoodName}, \n " +
                          $"Catogory: {f.TypeOfFood}, \n" +
                          $" Cost: {f.Price}, \n " +
                          $"{f.Restaurant} \n ");
    }

}


#endregion

#region AddNewFoodBox

void AddNewFoodBox()
{
    string FoodName = "";
    string TypeOfFood = "";
    decimal price = 0;
    bool loop = true;

    while (loop)
    {
        while (loop)
        {
            Console.Clear();
            // adding the meal with condition 
            Console.WriteLine("\n \t Enter a new meal\n\n\t\t");
            FoodName = Console.ReadLine();
            if (FoodName.Length < 2 || FoodName.Length > 30)
            {
                Console.WriteLine("\n \t Your meal name has to be between 2 and 30 chars" +
                                  "Press enter to try again");
                Console.ReadKey();
            }
            else
            {
                loop = false;
            }
        }

        loop = true;

        while (loop)
        {
            Console.Clear();

            // adding a catogory with condition
            Console.WriteLine("\n \t Enter the type of the meal \n\n\t\t ");
            TypeOfFood = Console.ReadLine();

            if (TypeOfFood.Length < 2 || TypeOfFood.Length > 20)
            {
                Console.WriteLine(" \n \t Your catogory name has to be between 2 and 20" +
                                  "Press enter to try again");
                Console.ReadKey();
            }
            else
            {
                loop = false;
            }
        }

        loop = true;

        while (loop)
        {
            Console.Clear();

            // adding a price 
            Console.WriteLine("\n \t Enter the price for the meal");

            price = decimal.Parse(Console.ReadLine());

            break;
        }

        string restaurantId = "FoodRescue_ProjectDatabase_REAL";
        string databaseName = "FoodRescue_ProjectDatabase_REAL";
        var restaurant = new RestaurantBackend(1, databaseName);

        restaurant.AddFoodBox(FoodName, TypeOfFood, price);

        Console.WriteLine($"\t the {FoodName} has been added to the database successfully \t \n " +
                           "\t Here comes all of the foodpackages available in the restaurant \n \n \n");

        var allFoodPackages = restaurant.GetAllFoodBoxes();

        foreach (var f in allFoodPackages)
        {
            Console.WriteLine($"ID: {f.FoodboxId}, \t Meal: {f.FoodName},  \t \t  Catagory:{f.TypeOfFood},  \t \t Cost: {f.Price},  \t \t  {f.Restaurant}");
        }

        break;
    }

    Console.WriteLine(" \n \n \n Press ENTER to go back to the main menu");
    Console.ReadKey();

}
#endregion


#region Option 0 (leaving the program)
bool ExitProgramPrompt()
{
    while (true)
    {
        Console.Clear();

        string prompt = "Are you sure you want to exit the program?";
        bool answer = YesNoPrompt(prompt, true);

        if (answer)
        {
            return false;
        }

        if (!answer)
        {
            return true;
        }

        Console.Clear();
    }
}

bool YesNoPrompt(string outputPrompt, bool clearConsole)
{
    while (true)
    {
        Console.Write($"\t{outputPrompt}\n\n\t[y/n]\t");

        var keyInfo = Console.ReadKey();

        if (keyInfo.Key == ConsoleKey.Y)
        {
            if (clearConsole)
            {
                Console.Clear();
            }
            return true;
        }

        if (keyInfo.Key == ConsoleKey.N)
        {
            if (clearConsole)
            {
                Console.Clear();
            }
            return false;
        }

        if (clearConsole)
        {
            Console.Clear();
        }
    }
}

void ReturnToMainMenuPrompt()
{
    Console.Write("\n\tPlease press enter to return to the menu");

    Console.ReadLine();
}
#endregion



