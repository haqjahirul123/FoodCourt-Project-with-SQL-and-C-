using DataLayer.Backend;
using DataLayer.Data;

var builder = WebApplication.CreateBuilder(args);
//var admin = new AdminBackend( );

string databaseName = "FoodRescue_ProjectDatabase_REAL";
var admin = new AdminBackend(databaseName);    //fix connection
admin.CreateAndSeedDb();

//using var ctx = new FoodRescue_DbContext();
//Console.WriteLine(ctx);

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
