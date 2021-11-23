using DataLayer.Data;
using DataLayer.Model;
using DataLayer.Backend;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages.FoodBoxes;

public class IndexModel : PageModel
{
    private readonly RestaurantBackend _restaurantBackend;

    public IndexModel()
    {
        _restaurantBackend = new RestaurantBackend(1);
    }

    public IList<FoodBox> FoodBoxes { get;set; }

    public async Task OnGetAsync(int? sold)
    {
        FoodBoxes = await _restaurantBackend.GetAllFoodBoxesAsync();
    }
}