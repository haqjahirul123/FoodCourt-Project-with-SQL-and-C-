using DataLayer.Backend;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages.FoodBoxes;

public class DetailsModel : PageModel
{
        

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
}