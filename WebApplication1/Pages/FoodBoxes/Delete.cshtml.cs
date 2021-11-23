using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Data;
using DataLayer.Model;

namespace WebApplication1.Pages.FoodBoxes;

public class DeleteModel : PageModel
{
    private readonly DataLayer.Data.FoodRescue_DbContext _context;

    public DeleteModel(DataLayer.Data.FoodRescue_DbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public FoodBox FoodBox { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        FoodBox = await _context.FoodBoxes.FirstOrDefaultAsync(m => m.FoodboxId == id);

        if (FoodBox == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        FoodBox = await _context.FoodBoxes.FindAsync(id);

        if (FoodBox != null)
        {
            _context.FoodBoxes.Remove(FoodBox);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}