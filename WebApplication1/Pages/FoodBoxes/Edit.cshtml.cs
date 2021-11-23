using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Backend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer.Data;
using DataLayer.Model;

namespace WebApplication1.Pages.FoodBoxes;

public class EditModel : PageModel
{
    private RestaurantBackend _restaurantBackend;
    public EditModel()
    {
        _restaurantBackend = new RestaurantBackend(1);
    }

    [BindProperty]
    public FoodBox FoodBox { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        FoodBox = await GeneralInfoBackend.GetFoodBox(id);

        if (FoodBox == null)
        {
            return NotFound();
        }
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        _restaurantBackend.EditFoodBox(FoodBox);
            
        return RedirectToPage("./Index");
    }

        
}