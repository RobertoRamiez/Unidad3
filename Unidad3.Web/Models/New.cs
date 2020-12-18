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

        public int DeveloperId { get; set; }
        [ForeignKey("DeveloperId")]
        public Developer Desarrollador { get; set; }
        
        [Display(Name ="Fecha de lanzmiento")]
        public DateTime DateTime { get; set; }

        public string Photo { get; set; }

        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
    }
}