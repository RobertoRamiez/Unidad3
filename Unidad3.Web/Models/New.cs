using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unidad3.Web.Models
{
    public class New
    {
        public int Id { get; set; }

        public string ApplicationUser { get; set; }
        [Display(Name ="Desarrollador")]
        [ForeignKey("ApplicationUser")]
        public ApplicationUser Desarrollador { get; set; }
        
        [Display(Name ="Fecha de lanzmiento")]
        public DateTime DateTime { get; set; }
        
        [Display(Name ="Genero")]
        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        [Display(Name ="Genero")]
        public Genre Genere { get; set; }

        public string Photo { get; set; }
    }
}