using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KutuphaneYonetimSistemi.Data;
using KutuphaneYonetimSistemi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;



namespace KutuphaneYonetimSistemi.Controllers
{

    

    [Authorize]
    public class KitaplarController : Controller
    {
        private readonly VeritabaniBaglam _baglam;

        public KitaplarController(VeritabaniBaglam baglam)
        {
            _baglam = baglam;
        }
        [AllowAnonymous]
        public IActionResult Goruntule()
        {
            var kitaplar = _baglam.Kitaplar.ToList();
            return View(kitaplar);
        }

    [AllowAnonymous]
    public IActionResult Detay(int id)
    {
        var kitap = _baglam.Kitaplar.FirstOrDefault(k => k.Id == id);
        if (kitap == null)
        {
            return NotFound(); // 404 döner
        }
        return View(kitap); // Detay.cshtml'e kitap nesnesini yollar
    }


        public IActionResult Index()
        {
            var kitaplar = _baglam.Kitaplar.ToList();
            return View(kitaplar);
        }


        public IActionResult Ekle() => View();

        [HttpPost]
        public IActionResult Ekle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _baglam.Kitaplar.Add(kitap);
                _baglam.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kitap);
        }



        public IActionResult Duzenle(int id)
        {
            // Seçilen kitabı veritabanından buluyoruz
            var kitap = _baglam.Kitaplar.Find(id);

            if (kitap == null)
            {
                return NotFound();  // Kitap bulunmazsa hata döndürüyoruz
            }

            return View(kitap);  // Kitap verilerini view'a gönderiyoruz
        }


        [HttpPost]
        public IActionResult Duzenle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _baglam.Kitaplar.Update(kitap);  // Veritabanındaki kitap kaydını güncelliyoruz
                _baglam.SaveChanges();  // Değişiklikleri kaydediyoruz
                return RedirectToAction("Index");  // Ana sayfaya yönlendiriyoruz
            }

            return View(kitap);  // Eğer model geçerli değilse, formu tekrar gösteriyoruz
        }





public IActionResult Sil(int id)
{
    var kitap = _baglam.Kitaplar.Find(id);
    if (kitap == null)
    {
        return NotFound();
    }

    return View(kitap);  // Silme onay sayfasına yönlendirir
}

[HttpPost, ActionName("Sil")]
public IActionResult SilOnay(int id)
{
    var kitap = _baglam.Kitaplar.Find(id);
    if (kitap == null)
    {
        return NotFound();  // Kitap bulunamazsa hata döndürüyoruz
    }

    _baglam.Kitaplar.Remove(kitap);  // Kitap silme işlemi
    _baglam.SaveChanges();  // Veritabanına kaydetme
    return RedirectToAction("Index");  // Başka bir sayfaya yönlendirme
}



    }
}