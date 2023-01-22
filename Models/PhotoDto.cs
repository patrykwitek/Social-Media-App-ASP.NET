using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using NuGet.Packaging.Signing;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace aplikacja_zdjecia_z_wakacji.Models
{
    public class PhotoDto
    {
        public PhotoDto()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
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

        public string FileName { get; set; }

        public DateTime Data { get; set; }

        [HiddenInput]
        public string User { get; set; }

        virtual public List<Comment> Comments { get; set; }

        virtual public List<Like> Likes { get; set; }
    }
}
