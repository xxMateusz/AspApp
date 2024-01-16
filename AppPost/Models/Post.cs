using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AppPost.Models
{
    public class Post
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wprowadź zawartość posta!")]
        [Display(Name = "Zawartość")]

        public string Content { get; set; }

        [Required(ErrorMessage = "Podaj autora!")]
        [Display(Name = "Autor")]
        public string Author { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Publikacji")]

        public DateTime PublicationDate { get; set; }



        [Display(Name = "Tagi")]
        public string Tags { get; set; }

        [StringLength(500, ErrorMessage = "Komentarz nie może przekraczać 500 znaków")]
        [Display(Name = "Komentarz")]
        public string Comment { get; set; }
        [Display(Name = "Data utworzenia")]
        [HiddenInput]
        public DateTime Created { get; set; }
    }
}
