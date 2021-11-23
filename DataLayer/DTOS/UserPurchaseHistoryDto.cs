using System;
using System.Collections.Generic;
using DataLayer.Model;

namespace DataLayer.DTOS;

public class UserPurchaseHistoryDto
{
    public DateTime DateOfPurchase { get; set; }
    public List<FoodBox> FoodBoxes { get; set; }
    public Restaurant Restaurant { get; set; }
}