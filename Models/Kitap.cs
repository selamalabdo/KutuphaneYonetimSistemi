using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace KutuphaneYonetimSistemi.Models
{
    public class Kitap
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Kitap Adı")]
        public string? KitapAdi { get; set; }

        [Required]
        [Display(Name = "Yazar")]
        public string? Yazar { get; set; }

        [Display(Name = "Yayın Yılı")]
        public int YayinYili { get; set; }

        [Display(Name = "Tür")]
        public string? Tur { get; set; }

            [Display(Name = "Fiyat")]
       public decimal? Fiyat { get; set; }


    }
}
