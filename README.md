# KutuphaneYonetimSistemi

Bu proje, bir **Kütüphane Yönetim Sistemi** geliştirmek amacıyla oluşturulmuştur. Kullanıcılar kitapları görüntüleyebilir, kitapları sepete ekleyebilir ve kütüphane envanterini yönetebilirler.

## Proje Özeti

Bu sistem, kütüphanedeki kitapların veritabanına kaydedilmesi, düzenlenmesi, silinmesi ve görüntülenmesi için temel bir **ASP.NET Core MVC** uygulamasıdır. Ayrıca kullanıcılar sepete kitap ekleyip, sepetlerini görüntüleyebilirler.

## Özellikler

- **Kitap Listeleme**: Kütüphanedeki tüm kitapları listeleme.
- **Kitap Ekleme**: Yeni kitap ekleyebilme.
- **Kitap Detayı**: Kitapların detaylı bilgilerini görüntüleme.
- **Kitap Düzenleme**: Kitap bilgilerini güncelleyebilme.
- **Kitap Silme**: Kitapları silebilme.
- **Sepete Ekleme**: Kullanıcılar kitapları sepete ekleyebilir.
- **Sepetim**: Kullanıcılar sepetteki kitapları görüntüleyebilir.

## Başlangıç

### Gereksinimler

- **.NET 6.0** veya üzeri
- **SQL Server** (veya başka bir veritabanı yönetim sistemi)

### Kurulum Adımları

1. **Projeyi indirin**:
   ```bash
   git clone https://github.com/yourusername/KutuphaneYonetimSistemi.git
   cd KutuphaneYonetimSistemi

	2. NuGet paketlerini yükleyin:
dotnet restore

	3. Veritabanı Bağlantısını Yapılandırın: appsettings.json dosyasını açın ve ConnectionStrings bölümünde veritabanı bağlantısını yapılandırın.
{
  "ConnectionStrings": {
    "VarsayilanBaglanti": "Server=yourserver;Database=KutuphaneDB;Trusted_Connection=True;"
  }
}

	4. Veritabanı Migrasyonlarını Uygulayın: Veritabanını oluşturmak ve ilk migrasyonu uygulamak için aşağıdaki komutları çalıştırın:
dotnet ef migrations add InitialCreate
dotnet ef database update

	5. Uygulamayı Başlatın:
dotnet run

Uygulama şimdi http://localhost:5000 adresinde çalışıyor olmalıdır.
Kullanıcı Girişi
Uygulama, kullanıcı doğrulaması gerektirir. Sisteme giriş yapmak için aşağıdaki adımları izleyebilirsiniz:
	1. Kullanıcı Kaydı: Giriş sayfasından kullanıcı kaydı yapabilirsiniz.
	2. Kullanıcı Girişi: Var olan bir kullanıcı ile giriş yaparak uygulamayı kullanabilirsiniz.
Uygulama Yapısı
Controllers/KitaplarController.cs
	• Kitaplarla ilgili işlemleri yöneten controller. Kitap ekleme, düzenleme, silme ve listeleme işlemleri burada yapılır.
Görünümler (Views/Kitaplar/):
	• Index.cshtml: Kitapların listelendiği ana sayfa.
	• Ekle.cshtml: Yeni kitap eklemek için kullanılan form sayfası.
	• Goruntule.cshtml: Kitapların detaylarını görüntüleme sayfası.
	• Duzenle.cshtml: Mevcut kitabın bilgilerini düzenlemek için kullanılan form sayfası.
	• Detay.cshtml: Kitabın detaylı bilgilerini gösteren sayfa.
	• Sil.cshtml: Kitap silme işlemi için onay sayfası.
Controllers/SepetController.cs
	• Kullanıcıların kitapları sepete ekleyebileceği ve sepetlerini görüntüleyebileceği controller.
Görünümler (Views/Sepet/):
	• Sepetim.cshtml: Kullanıcının sepetteki kitapları görüntüleyebileceği sayfa.
Controllers/AdminController.cs
	• Yönetici paneli ve admin işlemleri için controller.
Görünümler (Views/Admin/):
	• Panel.cshtml: Yönetici paneline ait sayfa.
Controllers/GirisController.cs
	• Kullanıcı giriş işlemleri için controller.
Görünümler (Views/Giris/):
	• GirisYap.cshtml: Kullanıcı giriş sayfası.
Kullanıcı Arayüzü
Bu uygulama, kullanıcı dostu bir arayüze sahiptir ve ASP.NET Core MVC kullanılarak geliştirilmiştir. Uygulama, tüm sayfalarda responsive (mobil uyumlu) tasarım sunar.
Katkıda Bulunma
Eğer bu projeye katkıda bulunmak isterseniz, aşağıdaki adımları izleyebilirsiniz:
	1. Bu repository'yi fork'layın.
	2. Yeni bir branch oluşturun (git checkout -b feature-xyz).
	3. Değişikliklerinizi yapın ve commit edin (git commit -am 'Add new feature').
	4. Değişikliklerinizi push'layın (git push origin feature-xyz).
	5. Pull request gönderin.
Lisans
Bu proje, MIT Lisansı altında lisanslanmıştır. Detaylar için LICENSE dosyasına göz atabilirsiniz.

---

### Açıklamalar

- **Controller ve View İlişkisi**: Her controller'ın ilgili view dosyaları vardır. Bu view dosyaları, controller tarafından işlenen veriyi kullanıcıya gösteren HTML sayfalarıdır.
- **Admin, Sepet, Kitaplar ve Giriş** gibi farklı view klasörleri, farklı işlemleri kontrol etmek ve yönetmek için kullanılır. Örneğin:
  - `Admin/Panel.cshtml` dosyası, admin panelinin görsel temsilini sağlar.
  - `Kitaplar/Detay.cshtml` dosyası, bir kitabın detaylarını kullanıcıya sunar.
  - `Sepet/Sepetim.cshtml` dosyası, kullanıcının sepetindeki kitapları gösterir.


