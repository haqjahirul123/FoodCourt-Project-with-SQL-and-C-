using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DataLayer.DTOS;
using DataLayer.Model;

namespace ConsoleApp;

public static class ConsoleHelper
{
    /// <summary>
    /// Printar alla users i listan till konsollen. En rad i taget.
    /// </summary>
    /// <param name="userList">Listan vi vill printa</param>
    public static void PrintUsers(List<User> userList)
    {
        foreach (var user in userList)
        {
            Console.WriteLine(user.ToString());
        }
        
    }
    /// <summary>
    /// Printar alla restauranger i listan till konsollen
    /// </summary>
    /// <param name="restaurantList">Listan vi vill printa</param>
    public static void PrintRestaurants(List<Restaurant> restaurantList)
    {
        foreach (var restaurant in restaurantList)
        {
            Console.WriteLine(restaurant.ToString());
        }
    }
    /// <summary>
    /// Printar alla restauranger i listan till konsollen
    /// </summary>
    /// <param name="foodBoxList">Listan vi vill printa</param>
    public static void PrintFoodBoxes(List<FoodBox> foodBoxList)
    {
        foreach (var foodBox in foodBoxList)
        {
            Console.WriteLine($"Restaurant: {foodBox.Restaurant.RestaurantName}\t Lunchbox: {foodBox.FoodName}\t Food type: {foodBox.TypeOfFood}\t Price: {foodBox.Price.ToString("C",new CultureInfo("sv-SE"))}");
        }
    }
    /// <summary>
    /// Printar förtjänsten i alla restauranger och hur många sålda food boxes de har sålt
    /// </summary>
    /// <param name="restaurantList">Listan vi vill printa</param>
    public static void PrintProfitsInAllRestaurants(List<RestaurantProfitDto> restaurantList)
    {
        foreach (var restaurant in restaurantList)
        {
            Console.WriteLine($"Restaurant: {restaurant.RestaurantName}\t Profit: {restaurant.Profit.ToString("C", new CultureInfo("sv-SE"))}\t Sold food boxes:{restaurant.SoldFoodBoxes}");
        }
    }
    /// <summary>
    /// Printar ut i konsollen historiken i listan.
    /// </summary>
    /// <param name="userHistory">Listan vi vill printa</param>
    public static void PrintUserHistory(List<UserPurchaseHistoryDto> userHistory)
    {
        foreach (var order in userHistory)
        {
            Console.WriteLine("Purchase date: " + order.DateOfPurchase.ToShortDateString());
            PrintFoodBoxes(order.FoodBoxes);
        }
    }
}