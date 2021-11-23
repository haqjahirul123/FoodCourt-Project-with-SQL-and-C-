using DataLayer.Backend;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    public IList<Restaurant> Restaurants { get; set; }
    public void OnGet()
    {
        var admin = new AdminBackend();
        Restaurants = admin.GetRestaurants();
    }
}