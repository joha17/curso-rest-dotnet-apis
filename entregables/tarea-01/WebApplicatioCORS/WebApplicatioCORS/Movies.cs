using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCORS
{
    public class Movies
    {
        public int IdPelicula { get; set; }
        public String Titulo { get; set; }
        public String Descripcion { get; set; }
        public DateTime FechaEstreno { get; set; }
        public String Url { get; set; }
    }
}
