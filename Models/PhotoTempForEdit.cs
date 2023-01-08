using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace aplikacja_zdjecia_z_wakacji.Models
{
    //Pomocnicza klasa, aby przenieść dane do kontrolera podczas edycji zdjęcia
    public class PhotoTempForEdit
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Podanie nazwy wymagane!")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Podanie miejsca wymagane!")]
        public string Miejsce { get; set; }

        [Required(ErrorMessage = "Podanie opisu wymagane!")]
        [MaxLength(length: 1000, ErrorMessage = "Opis nie może przekraczać 1000 znaków!")]
        public string Opis { get; set; }
    }
}