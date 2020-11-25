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
        
        [Display(Name ="Desarrollador")]
        public ApplicationUser Desarrollador { get; set; }
        
        [Display(Name ="Fecha de lanzmiento")]
        public DateTime DateTime { get; set; }
        
        [Display(Name ="Genero")]
        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genere { get; set; }
    }
}