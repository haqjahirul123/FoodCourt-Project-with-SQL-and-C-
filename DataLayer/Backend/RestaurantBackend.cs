using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.DTOS;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Backend;

public class RestaurantBackend
{
    private readonly int _restaurantId;
    public RestaurantBackend(int restaurantId)
    {
        _restaurantId = restaurantId;
    }

    /// <summary>
    /// Ta fram alla sålda matlådor
    /// </summary>
    /// <returns> En lista med sålda foodboxes för inloggade restaurangen </returns>
    public List<FoodBox> GetSoldFoodBoxes()
    {
        using var ctx = new FoodRescue_DbContext();

        var query = ctx.FoodBoxes
            .Include(f=>f.Restaurant)
            .Where(f => f.Restaurant.RestaurantId == _restaurantId
                        && f.Purchase != null)
            .OrderBy(f => f.Purchase.DateOfPurchase);

        return query.ToList();
    }
    /// <summary>
    /// Lägg till en matlåda
    /// </summary>
    /// <param name="foodName"> Namnet på foodboxen </param>
    /// <param name="typeOfFood"> Typen av mat </param>
    /// <param name="price"> Priset i kronor </param>
    public void AddFoodBox(string foodName, string typeOfFood, decimal price)
    {
        using var ctx = new FoodRescue_DbContext();
        
            var restaurant = ctx.Restaurants
                .FirstOrDefault(r => r.RestaurantId == _restaurantId);
            if (restaurant == null) throw new NullReferenceException("The restaurant does not exist");

            var foodBox = new FoodBox
            {
                TypeOfFood = typeOfFood,
                FoodName = foodName,
                Restaurant = restaurant,
                Price = price
            };

            ctx.FoodBoxes.Add(foodBox);
            ctx.SaveChanges();
        
    }
    /// <summary>
    /// Ta fram alla matlådor på restaurangen
    /// </summary>
    /// <returns> En lista med med alla matlådor på den inloggade restaurangen </returns>
    public List<FoodBox> GetAllFoodBoxes()
    {
        using var ctx = new FoodRescue_DbContext();

        var query = ctx.FoodBoxes
            .Include(f => f.Restaurant)
            .Include(f=>f.Purchase)
            .Where(f => f.Restaurant.RestaurantId == _restaurantId);

        return query.ToList();
    }

    /// <summary>
    /// Förtjänst för restaurangen.
    /// </summary>
    /// <param name="month"> Vilken månad vi vill kolla på </param>
    /// <param name="year"> Vilket år vi vill kolla på </param>
    /// <returns> Ett anonymt objekt med förtjänten (i kronor) och antalet sålda food boxes </returns>
    public RestaurantProfitDto GetProfit(int month, int year)
    {
        using var ctx = new FoodRescue_DbContext();

        var query = ctx.FoodBoxes
            .Where(f => f.Restaurant.RestaurantId == _restaurantId
                        && f.Purchase.DateOfPurchase.Month == month
                        && f.Purchase.DateOfPurchase.Year == year
                        && f.Purchase != null);

        return new RestaurantProfitDto
        {
            Profit = query.Sum(f => f.Price),
            SoldFoodBoxes = query.Count()
        };
    }
    /// <summary>
    /// Ta fram en full information om den inloggade restaurangen
    /// </summary>
    /// <returns> Ett Restaurant objekt </returns>
    public Restaurant GetLoggedInRestaurantInfo()
    {
        using var ctx = new FoodRescue_DbContext();

        return ctx.Restaurants.Find(_restaurantId);
    }
}