using FirstProject_RP.CoreLayer.Services.Posts;
using FirstProject_RP.DataLayer.Context;
using FirtsProject_RP.CoreLayer.Services.Categories;
using FirtsProject_RP.CoreLayer.Services.FileManager;
using FirtsProject_RP.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
        sqlOptions => sqlOptions.MigrationsAssembly("FirstProject-RP.DataLayer")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddTransient<IFileManager , FileManager>();



builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    option.LoginPath = "/auth/login";
    option.LogoutPath = "/Auth/Logout";
    option.ExpireTimeSpan = TimeSpan.FromDays(30);
});


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

app.UseAuthentication();
app.UseAuthorization();




app.MapControllerRoute(
    name: "Default",
    pattern: "{area=exists}/{controller=Home}/{action=Index}/{id?}");

//app.MapAreaControllerRoute(
//    name: "AdminPanel",
//    areaName: "Admin",
//    pattern: "erfan/{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();




app.Run();

