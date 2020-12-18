using System.ComponentModel.DataAnnotations;

namespace Unidad3.Web.Models
{
    public class Developer
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name="Contacto")]
        public string Contact { get; set; }
        
    }
}