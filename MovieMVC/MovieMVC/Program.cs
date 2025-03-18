using Microsoft.AspNetCore.Authentication.Cookies;
using MovieMVC.Models;
using MovieMVC.Repostiories.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// GenericRepository 
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped(typeof(GenericRepository<>));

builder.Services.AddControllers();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/UserSignIn/Index"; // Giriþ sayfasýnýn yolu
		options.LogoutPath = "/UserSignIn/Logout"; // Çýkýþ sayfasýnýn yolu
	});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();