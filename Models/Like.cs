using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace aplikacja_zdjecia_z_wakacji.Models
{
    public class Like
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        public string User { get; set; }
        public Post? Post { get; set; }
    }
}
