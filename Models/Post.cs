using System.ComponentModel.DataAnnotations;

namespace aplikacja_zdjecia_z_wakacji.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole wymagane!")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Pole wymagane!")]
        public string Miejsce { get; set; }
        [MaxLength(length: 1000, ErrorMessage = "Opis nie może przekraczać 1000 znaków!")]
        public string Opis { get; set; }
        public string? Photo { get; set; }
        public DateTime Data { get; set; }
    }
}
