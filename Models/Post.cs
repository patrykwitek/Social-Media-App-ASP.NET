using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace aplikacja_zdjecia_z_wakacji.Models
{
    public class Post
    {
        public Post()
        {
            Comments = new List<Comment>();

            Comment comment = new Comment();
            comment.Tresc = "Test222";
            comment.User = "user";
            Comments.Add(comment);
        }

        [HiddenInput]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Podanie nazwy wymagane!")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Podanie miejsca wymagane!")]
        public string Miejsce { get; set; }
        [Required(ErrorMessage = "Podanie opisu wymagane!")]
        [MaxLength(length: 1000, ErrorMessage = "Opis nie może przekraczać 1000 znaków!")]
        public string Opis { get; set; }
        public string? Photo { get; set; }
        public DateTime Data { get; set; }
        [HiddenInput]
        public string User { get; set; }
        virtual public List<Comment> Comments { get; set; }
    }
}
