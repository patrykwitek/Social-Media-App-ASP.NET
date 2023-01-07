using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace aplikacja_zdjecia_z_wakacji.Models
{
    public class LikeForComment
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        public string User { get; set; }
        public Comment? Comment { get; set; }
    }
}
