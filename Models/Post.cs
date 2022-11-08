using System.ComponentModel.DataAnnotations;

namespace aplikacja_zdjecia_z_wakacji.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public string Miejsce { get; set; }
        [MaxLength(length: 1000, ErrorMessage = "Opis nie może przekraczać 1000 znaków!")]
        public string Opis { get; set; }
        public string Photo { get; set; }
        public DateTime Data { get; set; }
    }
}
