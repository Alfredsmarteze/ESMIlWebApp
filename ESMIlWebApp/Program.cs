using DataContextStructure;
using Infrastructure.Interface;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<ESMContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUnitRepository, UnitRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(

//endpoints.MapControllerRoute(
//              name: "areas",
//              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

//name: "default",
//    pattern: "{controller=UnitManagement}/{action=CreateNewPrayer}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
                  name: "unit",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "unit",
        pattern: "{controller=UnitManagement}/{action=BibleStudyUnit}/{id?}");
});
app.Run();
