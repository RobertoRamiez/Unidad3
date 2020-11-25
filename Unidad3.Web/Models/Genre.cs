using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Unidad3.Web.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Genero")]
        public string Nombre { get; set; }

        public ICollection<New> News { get; set; }
    }
}