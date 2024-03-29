using DataContextStructure;
using DataStructure;
using Infrastructure.Interface;
using Infrastructure.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<ESMContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddRazorPages();   
builder.Services.AddControllersWithViews()
    .AddJsonOptions(s => { s.JsonSerializerOptions.PropertyNameCaseInsensitive = true; s.JsonSerializerOptions.PropertyNamingPolicy = null; });

builder.Services.AddTransient<IAdminControl, AdminControlRepository>();
builder.Services.AddTransient<ITestimonyRepository, TestimonyRepository>();
builder.Services.AddTransient<IUnitRepository, UnitRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IEmailRepository, EmailRepository>();
builder.Services.AddTransient<IGeneralMemberRepository, GeneralMemberRepository>();
builder.Services.AddTransient<IProgrammeTableRepository, ProgrammeTableRepository>();
builder.Services.AddTransient<IEsmafRepository, EsmafRepository>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequiredUniqueChars = 0;
    opt.Password.RequiredLength = 8;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireNonAlphanumeric = false;

    opt.SignIn.RequireConfirmedAccount = true;
})
    .AddEntityFrameworkStores<ESMContext>()
    .AddDefaultTokenProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddEventSourceLogger();
builder.Logging.AddNLog();

//builder.Services.Configure<IdentityOptions>(opts => {
//    opts.SignIn.RequireConfirmedAccount = false;
//});

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

app.UseAuthentication();
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
                  pattern: "{controller=Home}/{action=Index}/{id?}");
    //endpoints.MapControllerRoute(
    //    name: "unit",
    //    pattern: "{controller=UnitManagement}/{action=BibleStudyUnit}/{id?}");
});
app.Run();
