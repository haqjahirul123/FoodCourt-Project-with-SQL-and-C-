using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Backend;

public class GeneralInfoBackend
{
    public static async Task<FoodBox> GetFoodBox(int? id)
    {
        await using var ctx = new FoodRescue_DbContext();
        var foodBox = await ctx.FoodBoxes
            .Include(f => f.Restaurant)
            .Include(f=> f.Purchase)
                .ThenInclude(s => s.User)
                    .ThenInclude(u => u.PrivateInfo)
            .FirstOrDefaultAsync(m => m.FoodboxId == id);

        return foodBox;
    }
}