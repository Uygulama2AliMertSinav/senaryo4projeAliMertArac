using System.ComponentModel.DataAnnotations;

namespace AliMertTosunAracSinavi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Soyad zorunlu")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email zorunlu")]
        [EmailAddress(ErrorMessage = "Geçerli email giriniz")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre zorunlu")]
        public string Password { get; set; } = string.Empty;

        // Admin kontrolü için
        public bool IsAdmin { get; set; } = false;
    }
}