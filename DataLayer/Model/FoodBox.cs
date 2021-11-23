using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model;

public class FoodBox
{
    [Key]
    [Display(Name = "Food box Id")]
    public int FoodboxId { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 2)]
    [Display(Name = "Type of food")]
    public string TypeOfFood { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 2)]
    [Display(Name = "Food name")]
    public string FoodName { get; set; }

    [Required]
    [Column(TypeName = "smallmoney")]
    public decimal Price { get; set; }

    [Required]
    public Restaurant Restaurant { get; set; }

    [DisplayFormat(NullDisplayText = "Up for sale")]
    public Sale Purchase { get; set; }
}