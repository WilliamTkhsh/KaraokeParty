using KaraokePartyWebApp.Data;
using KaraokePartyWebApp.Interfaces;
using KaraokePartyWebApp.Models;
using KaraokePartyWebApp.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IKaraokeClubRepository, KaraokeClubRepository>();
builder.Services.AddScoped<IKaraokeGroupRepository, KaraokeGroupRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        "server=localhost;initial catalog=KARAOKE_PARTY;uid=root;pwd=hqeqb3m2",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"))
    );

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie();

var app = builder.Build();

await Seed.SeedRolesAsync(app);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
