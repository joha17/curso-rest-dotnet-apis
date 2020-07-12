using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi
{
    public class Movie
    {
        public int IdPelicula { get; set; }
        public String Titulo { get; set; }
        public String Descripcion { get; set; }
        public DateTime FechaEstreno { get; set; }
        public String Url { get; set; }

        public Movie() { }

        public Movie(int id, String titulo, String desc, DateTime fecha, String url)
        {
            this.IdPelicula = id;
            this.Titulo = titulo;
            this.Descripcion = desc;
            this.FechaEstreno = fecha;
            this.Url = url;
        }
    }
}
