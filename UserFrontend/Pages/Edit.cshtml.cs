using DataLayer.Backend;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserFrontend.Pages
{
    public class EditModel : PageModel
    {
        public UserBackend User { get; set; }

        [BindProperty] public FoodBox FoodBox { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = Program.User;
            User.BuyFoodBox(id);

            return RedirectToPage("./Index");
        }
    }
}
