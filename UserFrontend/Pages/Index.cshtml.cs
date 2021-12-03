using DataLayer.Backend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using UserFrontend.Models;

namespace UserFrontend.Pages
{
    public class IndexModel : PageModel
    {
        public UserBackend User { get; set; }
        public IList<FoodBox> FoodBox { get; set; }

        public async Task OnGetAsync()
        {
            User = new UserBackend(1, Program.DatabaseName);
            FoodBox = User.GetUnsoldFoodBoxes("Kött");
        }
    }
}