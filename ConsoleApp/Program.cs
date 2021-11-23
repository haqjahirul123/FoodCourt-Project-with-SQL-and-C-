using System;
using System.Collections;
using System.Globalization;
using DataLayer.Backend;
using static ConsoleApp.ConsoleHelper;

namespace ConsoleApp;

static class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Food Rescue Kim Björnsen Åklint";
        Console.SetWindowSize(200, 50);
        Console.ForegroundColor = ConsoleColor.Cyan;
        
        //Admin demo.
        AdminBackend admin = new();
        admin.CreateAndSeedDb();
        Console.WriteLine("Database restored and seeded!");
        Console.WriteLine("\nAdmin demonstration:");

        Console.ReadLine();
        var users = admin.GetUsers();
        Console.WriteLine("All the users:");
        PrintUsers(users);
        Console.ReadLine();

        Console.WriteLine("Deleting user with email 'Kim.bjornsen@hotmail.com'");
        admin.RemoveUser("Kim.bjornsen@hotmail.com");
        users = admin.GetUsers();
        Console.WriteLine("All the users:");
        PrintUsers(users);
        Console.ReadLine();

        var restaurants = admin.GetRestaurants();
        Console.WriteLine("\nAll the restaurants");
        PrintRestaurants(restaurants);
        Console.ReadLine();

        Console.WriteLine("Adding restaurant 'Burger Joint' with Phone number 0700 - 32 40 14");
        admin.AddRestaurant("Burger Joint", "0700 - 32 40 14");
        restaurants = admin.GetRestaurants();
        Console.WriteLine("\nAll the restaurants");
        PrintRestaurants(restaurants);
        Console.ReadLine();
            
        Console.WriteLine("\nProfit for all the restaurants November 2021");
        var restaurantsProfits = admin.GetProfitForAllRestaurants(11, 2021);
        PrintProfitsInAllRestaurants(restaurantsProfits);
        Console.ReadLine();

        Console.Clear();
        //User demo.
        Console.WriteLine("User demonstration:");
        UserBackend loggedInUser = new(1);

        Console.WriteLine("\nUnsold Food boxes with Kött");
        var unsoldFoodBoxes = loggedInUser.GetUnsoldFoodBoxes("Kött");
        PrintFoodBoxes(unsoldFoodBoxes);
        Console.ReadLine();

        Console.WriteLine("Buying Food box with id 1.");
        Console.WriteLine("\nUnsold Food boxes with Kött");
        loggedInUser.BuyFoodBox(1);
        unsoldFoodBoxes = loggedInUser.GetUnsoldFoodBoxes("Kött");
        PrintFoodBoxes(unsoldFoodBoxes);
        Console.ReadLine();
        
        Console.WriteLine("\nPurchase history for user with user Id 1");
        var history = loggedInUser.PurchaseHistory();
        PrintUserHistory(history);
        Console.ReadLine();

        Console.Clear();
        //Restaurant demo.
        Console.WriteLine("Restaurant demonstration:");
        RestaurantBackend restaurant = new(1);

        var restaurantInfo = restaurant.GetLoggedInRestaurantInfo();
        Console.WriteLine($"\nSold food boxes for Restaurant {restaurantInfo.RestaurantName}");
        PrintFoodBoxes(restaurant.GetSoldFoodBoxes());
        Console.ReadLine();

        Console.WriteLine($"\nAll food boxes at Restaurant {restaurantInfo.RestaurantName}");
        var foodBoxesOnOneRestaurant = restaurant.GetAllFoodBoxes();
        PrintFoodBoxes(foodBoxesOnOneRestaurant);

        Console.WriteLine("\nAdding food box 'Chicken Check' with 'Kött' and a price of 12 kr");
        restaurant.AddFoodBox("Chicken Check", "Kött", 12);

        Console.WriteLine($"\nAll food boxes at Restaurant {restaurantInfo.RestaurantName}");
        foodBoxesOnOneRestaurant = restaurant.GetAllFoodBoxes();
        PrintFoodBoxes(foodBoxesOnOneRestaurant);
        Console.ReadLine();

        Console.WriteLine($"\nProfit for Restaurant {restaurantInfo.RestaurantName} for November 2021");
        var profit = restaurant.GetProfit(11, 2021);
        Console.WriteLine($"Profit: {profit.Profit.ToString("C", new CultureInfo("sv-SE"))}\t Sold food boxes: {profit.SoldFoodBoxes}");
        Console.ReadLine();
    }
}