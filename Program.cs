/********************************************************************************************
 * Class representing the middleware of the application                                     *
 *******************************************************************************************/
//"CollegeCostContext": "Data Source=DataLayer//CollegeCost.db"
//"CollegeCostContext": "Data Source=Models\\DataLayer\\CollegeCost.db"

using Microsoft.EntityFrameworkCore;
using TuitionCalculator_WebApp.Models.DataLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//enable EF core dependency injection to provide a CollegeCostContext object to controllers that need one
builder.Services.AddDbContext<CollegeCostContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("CollegeCostContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();//allows http requests to be redirected as https
app.UseStaticFiles();//allows for static files 

app.UseRouting();

app.UseAuthorization();

//the default routing pattern used by the application
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
