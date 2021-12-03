using DataLayer.Backend;
using DataLayer.Data;

public class Program
{
    public static string DatabaseName = "FoodRescue_ProjectDatabase_REAL";
    public static UserBackend User = new UserBackend(1, DatabaseName);

    public static void Main(string[] args)
    {
        AdminBackend adminBackend = new(DatabaseName);
        adminBackend.CreateDb();

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
