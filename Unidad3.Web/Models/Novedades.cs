using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unidad3.Web.Models
{
    public class Novedades
    {
        public int Id { get; set; }
        public ApplicationUser Desarrollador { get; set; }
        public DateTime DateTime { get; set; }
        public string Lugar { get; set; }
        public int GenreId { get; set; }
        public Genre Genere { get; set; }
    }
}