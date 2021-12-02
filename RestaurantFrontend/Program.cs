using System.Data.Common;
using DataLayer.Backend;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

MainMenu();

void MainMenu()
{
    CreateDatabase();

    bool runTheProgram = true;

    #region Hela ConsoleAppen

    

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
                    //FindAllSoldFoodPackagesForYourRestaurant();
                    ReturnToMainMenuPrompt();
                    break;

                case 2:
                   //FindAllUnSoldFoodPackagesForYourRestaurant();
                    ReturnToMainMenuPrompt();
                    break;

                case 3:
                    //AddNewFoodBox();
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



#endregion