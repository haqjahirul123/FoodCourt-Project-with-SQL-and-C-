using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model;

public class Sale
{
    [Key]
    [Display(Name = "Purchase Number")]
    public int PurchaseNumber { get; set; }
    [Required]
    [DataType(DataType.Date), Display(Name = "Date of purchase"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime DateOfPurchase { get; set; }
    [Required]
    public User User { get; set; }
    public ICollection<FoodBox> FoodBoxes { get; set; }
}