using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DataLayer.Data;
using DataLayer.DTOS;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Backend;

public class UserBackend
{
    private readonly int _userId;
    private readonly string _databaseName;
    public UserBackend(int userId, string databaseName)
    {
        _databaseName = databaseName;
        _userId = userId;
    }
    /// <summary>
    /// Tar fram alla food som inte är köpta.
    /// </summary>
    /// <param name="typeOfFood"> Vilken typ av mat man vill se. </param>
    /// <returns> En lista av osålda food boxes av typen i "typeOfFood" </returns>
    public List<FoodBox> GetUnsoldFoodBoxes(string typeOfFood)
    {
        using var ctx = new FoodRescue_DbContext(_databaseName);

        var query = ctx.FoodBoxes
                .Include(f => f.Restaurant)
            .Where(f => f.TypeOfFood == typeOfFood && f.Purchase == null)
            .OrderBy(f => f.Price);
            
        return query.ToList();
    }
    /// <summary>
    /// Köper en foodbox. Köpet köps av inloggad user
    /// </summary>
    /// <param name="foodBoxId">Vilket Id foodboxen man vill köpa har</param>
    public void BuyFoodBox(int foodBoxId)
    {
        using var ctx = new FoodRescue_DbContext(_databaseName);
        var foodBox = ctx.FoodBoxes
            .Find(foodBoxId);
        if(foodBox == null) throw new Exception("There is no foodbox with that id");
        if (foodBox.Purchase != null) throw new Exception("That foodbox has already been bought.");

        var user = ctx.Users
            .Find(_userId);
        
        ctx.Sales
            .Add(new Sale
            {
                User = user,
                FoodBoxes = new[]{ foodBox }
            });
        ctx.SaveChanges();
    }
    /// <summary>
    /// Tar fram info om den inloggade usern.
    /// </summary>
    /// <returns>Ett user objekt</returns>
    public User GetUserInfo()
    {
        using var ctx = new FoodRescue_DbContext(_databaseName);

        return ctx.Users.Find(_userId);
    }
    /// <summary>
    /// Tar fram en lista med köphistoriken för den inloggade usern.
    /// </summary>
    /// <returns>En lista med köphistorik i form av en UserPurchaseHistoryDto</returns>
    public List<UserPurchaseHistoryDto> PurchaseHistory()
    {
        using var ctx = new FoodRescue_DbContext(_databaseName);

        var query = ctx.Sales
            .Where(s => s.User.UserId == _userId)
            .OrderBy(s => s.DateOfPurchase)
            .Select(s => new UserPurchaseHistoryDto
            {
                DateOfPurchase = s.DateOfPurchase,
                FoodBoxes = (List<FoodBox>)s.FoodBoxes.Select(f=> new FoodBox() { Restaurant = f.Restaurant, FoodName = f.FoodName, TypeOfFood = f.TypeOfFood, Price = f.Price })
            });

        return query.ToList();
    }
}