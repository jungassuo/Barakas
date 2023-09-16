using Barakas.Web.Service;
using Barakas.Web.Service.IService;
using Barakas.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

//Apsirasyti naudojamus servisus

builder.Services.AddHttpClient<IRoomService, RoomService>();

builder.Services.AddHttpClient<IProductService, ProductService>();

builder.Services.AddHttpClient<IAuthService, AuthService>();

//Priskirti servisu ip reiksmes

SD.RoomAPIBase = builder.Configuration["ServiceUrls:RoomAPI"];

SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];

SD.ProductAPIBase = builder.Configuration["ServiceUrls:ProductAPI"];

//Autentifikacijai reikalingas dalykas

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Uzregistruoti naudojamus servisus

builder.Services.AddScoped<ITokenProvider, TokenProvider>();

builder.Services.AddScoped<IBaseService, BaseService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IRoomService, RoomService>();

builder.Services.AddScoped<IProductService, ProductService>();

//Prideti autentifikacija kaip servisa ir apsirasyti path'us

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.ExpireTimeSpan = TimeSpan.FromHours(10);
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccessDenied";
});

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
