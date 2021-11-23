namespace DataLayer.DTOS;

public class RestaurantProfitDto
{
    public string RestaurantName { get; set; }
    public decimal Profit { get; set; }
    public int SoldFoodBoxes { get; set; }
}