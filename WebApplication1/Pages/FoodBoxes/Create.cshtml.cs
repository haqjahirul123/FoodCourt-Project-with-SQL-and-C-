using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Backend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer.Data;
using DataLayer.Model;

namespace WebApplication1.Pages.FoodBoxes;

public class CreateModel : PageModel
{
    private RestaurantBackend _restaurantBackend;
    public CreateModel()
    {
        _restaurantBackend = new RestaurantBackend(1);
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public FoodBox FoodBox { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        _restaurantBackend.AddFoodBox(FoodBox.FoodName, FoodBox.TypeOfFood, FoodBox.Price);

        return RedirectToPage("./Index");
    }
}