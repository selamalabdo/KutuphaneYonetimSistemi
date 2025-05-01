using KutuphaneYonetimSistemi.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Servisleri ekle
builder.Services.AddDbContext<VeritabaniBaglam>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VarsayilanBaglanti")));

builder.Services.AddControllersWithViews();

// 🔴 Bu satır yanlış yerdeydi, yukarı taşıdık
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Giris/GirisYap";
    });

var app = builder.Build();

// 2. Middleware'leri sırayla ekle
app.UseStaticFiles();
app.UseRouting();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // önce authentication
app.UseAuthorization();  // sonra authorization

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
