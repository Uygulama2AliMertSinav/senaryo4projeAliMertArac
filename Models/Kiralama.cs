using System;
using System.ComponentModel.DataAnnotations;

namespace AliMertTosunAracSinavi.Models
{
    public class Kiralama
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Araç adı zorunlu")]
        public string AracAdi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Başlangıç tarihi zorunlu")]
        public DateTime BaslangicTarihi { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunlu")]
        public DateTime BitisTarihi { get; set; }

        [Required(ErrorMessage = "Fotoğraf zorunlu")]
        public string FotoPath { get; set; } = string.Empty;

        public User? User { get; set; }
    }
}