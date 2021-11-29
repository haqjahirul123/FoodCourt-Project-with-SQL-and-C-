using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using DataLayer.Data;
using DataLayer.DTOS;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataLayer.Backend;

public class AdminBackend
{
    private readonly string _databaseName;
    public AdminBackend(string databaseName)
    {
        _databaseName = databaseName;
    }

    /// <summary>
    /// Återskapar och seedar databasen
    /// </summary>
    public void CreateAndSeedDb()
    {
        using var ctx = new FoodRescue_DbContext(_databaseName);
        ctx.Database.EnsureDeleted();
        ctx.SaveChanges();
        ctx.Database.EnsureCreated();

        ctx.Seed();
    }

    /// <summary>
    /// Skapar databasen om den inte finns, annars gör inget.
    /// </summary>
    public void CreateDb()
    {
        using var ctx = new FoodRescue_DbContext(_databaseName);
        if (ctx.Database.EnsureCreated())
        {
            ctx.Seed();
        }
    }

    /// <summary>
    /// Tar fram alla användare i databasen
    /// </summary>
    /// <returns> En lista med users. Deras Fullname och Email. </returns>
    public List<User> GetUsers()
    {
        using var ctx = new FoodRescue_DbContext(_databaseName);
        var query = ctx.Users
            .Include(u => u.PrivateInfo);
        
        return query.ToList();
    }
    /// <summary>
    /// Ta fram alla restauranger i databasen
    /// </summary>
    /// <returns> En lista med restauranger. Deras Name och PhoneNumber </returns>
    public List<Restaurant> GetRestaurants()
    {
        using var ctx = new FoodRescue_DbContext(_databaseName);
        var query = ctx.Restaurants;

        return query.ToList();
    }
    /// <summary>
    /// Lägg till en restaurang i databasen.
    /// </summary>
    /// <param name="name"> Namnet på restaurangen </param>
    /// <param name="phoneNumber"> Telefonnumret till restaurangen </param>
    public void AddRestaurant(string name, string phoneNumber)
    {
        using var ctx = new FoodRescue_DbContext(_databaseName);
        ctx.Restaurants.Add(new Restaurant { RestaurantName = name, PhoneNumber = phoneNumber });
        ctx.SaveChanges();
    }
    /// <summary>
    /// "Raderar" en användare genom att skriva över all känslig data med Deleted.
    /// </summary>
    /// <param name="email"> Email på usern </param>
    public void RemoveUser(string email)
    {
        using var ctx = new FoodRescue_DbContext(_databaseName);
        var userPrivateInfo = ctx.UserPrivateInfos
            .SingleOrDefault(upi => upi.Email.ToLower() == email.ToLower());

        if (userPrivateInfo == null) throw new Exception("There is no user with that email registered");

        ctx.UserPrivateInfos.Remove(userPrivateInfo);
        ctx.SaveChanges();
    }
    /// <summary>
    /// Visar förtjänst för alla restauranger
    /// </summary>
    /// <param name="month"> Månaden vi vill kolla på </param>
    /// <param name="year"> Året vi vill kolla på </param>
    /// <returns> En lista med Restaurangnamn, hur många matlådor den restaurangen har sålt och hur mycket förtjänst den restaurangen har den aktuella månaden. </returns>
    public List<RestaurantProfitDto> GetProfitForAllRestaurants(int month, int year)
    {
        using var ctx = new FoodRescue_DbContext(_databaseName);
        var query = ctx.Restaurants
            .Select(r => new
            {
                r.RestaurantName,
                FoodBoxes = r.FoodBoxes.Select(f => new
                {
                    f.Price,
                    f.Purchase,
                    month = f.Purchase.DateOfPurchase.Month,
                    year = f.Purchase.DateOfPurchase.Year
                }),
                foodBoxesSold = r.FoodBoxes.Count(f => f.Purchase.DateOfPurchase.Month == month 
                                                       && f.Purchase.DateOfPurchase.Year == year && f.Purchase != null),
                profit = r.FoodBoxes.Where(f => f.Purchase.DateOfPurchase.Month == month 
                                                && f.Purchase.DateOfPurchase.Year == year && f.Purchase != null).Sum(f => f.Price)
            })
            .OrderByDescending(g => g.profit)
            .Select(g => new RestaurantProfitDto()
            {
                RestaurantName = g.RestaurantName,
                SoldFoodBoxes = g.foodBoxesSold,
                Profit = g.profit
            });
        
        return query.ToList();
    }
            
}