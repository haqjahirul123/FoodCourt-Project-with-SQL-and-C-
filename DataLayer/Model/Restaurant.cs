using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model;

public class Restaurant
{
    [Key]
    [Display(Name = "Restaurant id")]
    public int RestaurantId { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3)]
    [Display(Name = "Restaurant Name")]
    public string RestaurantName { get; set; }

    [Phone]
    [Required]
    [StringLength(30, MinimumLength = 3)]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    public ICollection<User> Users { get; set; }

    public ICollection<FoodBox> FoodBoxes { get; set; }

    public override string ToString() => $"Restaurant name: {RestaurantName}\t Phone number: {PhoneNumber}";
    
}