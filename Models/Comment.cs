using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace aplikacja_zdjecia_z_wakacji.Models
{
    public class Comment
    {
        public Comment()
        {
            Likes = new List<LikeForComment>();
        }

        [HiddenInput]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nie została wprowadzona treść komentarza")]
        public string Tresc { get; set; }
        public string User { get; set; }
        public DateTime Data { get; set; }
        public int PhotoId { get; set; }
        public Photo? Post { get; set; }
        virtual public List<LikeForComment> Likes { get; set; }
    }
}