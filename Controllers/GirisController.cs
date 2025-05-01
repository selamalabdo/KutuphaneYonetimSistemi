using KutuphaneYonetimSistemi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class GirisController : Controller
{
    [HttpGet]
    public IActionResult GirisYap()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GirisYap(Kullanici kullanici)
    {
        if (kullanici.KullaniciAdi == "admin" && kullanici.Sifre == "1234") // Şifreyi değiştir :)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, kullanici.KullaniciAdi)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index", "Kitaplar");
        }

        ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
        return View();
    }

    public async Task<IActionResult> CikisYap()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Panel", "Admin");

    }
}
