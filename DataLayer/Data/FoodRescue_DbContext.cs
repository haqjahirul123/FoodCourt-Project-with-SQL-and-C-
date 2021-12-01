using Microsoft.EntityFrameworkCore;
using System;
using DataLayer.Model;


namespace DataLayer.Data;

public class FoodRescue_DbContext : DbContext
{
    private readonly string _databaseName;
    public FoodRescue_DbContext(string databaseName)
    {
        _databaseName = databaseName;
    }
    public DbSet<FoodBox> FoodBoxes { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<UserPrivateInfo> UserPrivateInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(@$"Server=(localdb)\MSSQLLocalDB;Database={_databaseName}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserPrivateInfo>()
            .HasIndex(upi => upi.Email)
            .IsUnique();

        modelBuilder.Entity<Sale>()
            .Property(s => s.DateOfPurchase)
            .HasDefaultValueSql("getdate()");
    }
    #region Seeding
    public void Seed()
    {
        var userPrivateInfos = new UserPrivateInfo[]
        {
            new() { Email = "Kim.bjornsen@hotmail.com", FirstName = "Kim", LastName = "Björnsen Åklint", Password = "Password1", IsAdmin = false },
            new() { Email = "Pia@hotmail.com", FirstName = "Pia", LastName = "Hagman", Password = "Password1", IsAdmin = false },
            new() { Email = "Johan@hotmail.com", FirstName = "Johan", LastName = "Fahlgren", Password = "Password1", IsAdmin = false },
            new() { Email = "Server@Mcdonalds.com", FirstName = "Server1", LastName = "", Password = "Password1MCD", IsAdmin = false },
            new() { Email = "admin@foodrescue.com", FirstName = "admin", LastName = "", Password = "Adminpassword1", IsAdmin = true }

        };
        var users = new User[]
        {
            new() {PrivateInfo = userPrivateInfos[0]},
            new() {PrivateInfo = userPrivateInfos[1]},
            new() {PrivateInfo = userPrivateInfos[2]},
            new() {PrivateInfo = userPrivateInfos[3]},
            new() {PrivateInfo = userPrivateInfos[4]}
        };
        Users.AddRange(users);
        var restaurants = new Restaurant[]
        {
            new() { RestaurantName = "Mcdonalds", PhoneNumber = "0700 - 82 32 11", Users = new[] {users[3]}},
            new() { RestaurantName = "Burger King", PhoneNumber = "0700 - 82 32 12" },
            new() { RestaurantName = "Max Burgers", PhoneNumber = "0700 - 82 32 13" }
        };

        var sales = new Sale[]
        {
            new() { User = users[0], DateOfPurchase = new DateTime(2021, 11, 10) },
            new() { User = users[1], DateOfPurchase = new DateTime(2021, 11, 9) },
            new() { User = users[2], DateOfPurchase = new DateTime(2021, 11, 4) },
            new() { User = users[0], DateOfPurchase = new DateTime(2021, 10, 10) }
        };
        
        var foodBoxes = new FoodBox[]
        {
            new() { TypeOfFood = "Kött", FoodName = "Cheese Burger", Price = 30.0M, Restaurant = restaurants[0], Purchase = sales[0] },
            new() { TypeOfFood = "Fisk", FoodName = "Fish and chips", Price = 31.0M, Restaurant = restaurants[0], Purchase = sales[0] },
            new() { TypeOfFood = "Vego", FoodName = "Haloumi burger", Price = 29.0M, Restaurant = restaurants[0], Purchase = sales[1] },
            new() { TypeOfFood = "Kött", FoodName = "Cheese Burger", Price = 30.0M, Restaurant = restaurants[0], Purchase = sales[1] },
            new() { TypeOfFood = "Kött", FoodName = "Hamburger", Price = 30.0M, Restaurant = restaurants[0], Purchase = sales[1] },
            new() { TypeOfFood = "Vego", FoodName = "Plant Burger", Price = 40.0M, Restaurant = restaurants[1], Purchase = sales[2] },
            new() { TypeOfFood = "Fisk", FoodName = "Fish Burger", Price = 30.0M, Restaurant = restaurants[0], Purchase = sales[3] },
            new() { TypeOfFood = "Kött", FoodName = "Cheese Burger", Price = 30.0M, Restaurant = restaurants[0], },
            new() { TypeOfFood = "Kött", FoodName = "Cheese Burger", Price = 30.0M, Restaurant = restaurants[0], },
            new() { TypeOfFood = "Fisk", FoodName = "Fish Burger", Price = 29.0M, Restaurant = restaurants[1], },
            new() { TypeOfFood = "Kött", FoodName = "Hamburger", Price = 39.0M, Restaurant = restaurants[1], },
            new() { TypeOfFood = "Vego", FoodName = "Plant Burger", Price = 30.0M, Restaurant = restaurants[2], },
            new() { TypeOfFood = "Kött", FoodName = "Spicy Hamburger", Price = 30.0M, Restaurant = restaurants[2], }
        };

        FoodBoxes.AddRange(foodBoxes);
        SaveChanges();
    }

    public void SeedRealDb()
    {
        var privateInfo = new UserPrivateInfo() {Email = "Server@Mcdonalds.com", FirstName = "Server1", LastName = "", Password = "Password1MCD"};
        var restaurant = new Restaurant {RestaurantName = "Mcdonalds", PhoneNumber = "0700 - 82 32 11"};
        var user = new User {PrivateInfo = privateInfo, Restaurant = restaurant};

        Users.Add(user);
        SaveChanges();
    }
    #endregion
}