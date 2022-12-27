using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace aplikacja_zdjecia_z_wakacji.Models
{
    public class Comment
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nie została wprowadzona treść komentarza")]
        public string Tresc { get; set; }
        public string User { get; set; }
        public DateTime Data { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}