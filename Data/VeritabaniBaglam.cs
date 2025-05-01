using Microsoft.EntityFrameworkCore;
using KutuphaneYonetimSistemi.Models;

namespace KutuphaneYonetimSistemi.Data
{
    public class VeritabaniBaglam : DbContext
    {
        public VeritabaniBaglam(DbContextOptions<VeritabaniBaglam> options) : base(options) { }

        public DbSet<Kitap> Kitaplar { get; set; }
    }
}
