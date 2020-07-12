using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MoviesWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {

        [HttpGet]
        public List<Movie> GetMovies()
        {
            List<Movie> AuthorList = new List<Movie>();

            Movie pelicula = new Movie(1, "Origen", "Dom Cobb es un ladrón con una extraña habilidad para entrar a los sueños de la gente y robarles los secretos de sus subconscientes. Su habilidad lo ha vuelto muy popular en el mundo del espionaje corporativo, pero ha tenido un gran costo en la gente que ama. Cobb obtiene la oportunidad de redimirse cuando recibe una tarea imposible: plantar una idea en la mente de una persona. Si tiene éxito, será el crimen perfecto, pero un enemigo se anticipa a sus movimientos.", new DateTime(2010, 8, 6), "https://is1-ssl.mzstatic.com/image/thumb/Video4/v4/86/ac/14/86ac14f2-8c9b-2a5a-80be-49b8ee402228/pr_source.lsr/268x0w.png");
            AuthorList.Add(pelicula);
            pelicula = new Movie(2, "El caballero oscuro", "Batman tiene que mantener el equilibrio entre el heroísmo y el vigilantismo para pelear contra un vil criminal conocido como el Joker, que pretende sumir Gotham City en la anarquía", new DateTime(2008, 8, 13), "https://images-na.ssl-images-amazon.com/images/I/41BorWGJegL._SX302_BO1,204,203,200_.jpg");
            AuthorList.Add(pelicula);
            pelicula = new Movie(3, "Piratas del Caribe: La maldición del Perla Negra", "Un herrero y un extraño pirata se unen para rescatar a una dama secuestrada de un capitán de piratas y su tripulación.", new DateTime(2003, 8, 14), "http://es.web.img2.acsta.net/c_215_290/medias/nmedia/18/91/06/54/20129011.jpg");
            AuthorList.Add(pelicula);
            pelicula = new Movie(4, "Avengers: Inifinity War", "Los superhéroes se alían para vencer al poderoso Thanos, el peor enemigo al que se han enfrentado. Si Thanos logra reunir las seis gemas del infinito: poder, tiempo, alma, realidad, mente y espacio, nadie podrá detenerlo.", new DateTime(2018, 4, 27), "http://t1.gstatic.com/images?q=tbn:ANd9GcS2xHmABIm07FlykPsdTlijgtafbiTD5UuRCFAdtkYl6doxJDGi");
            AuthorList.Add(pelicula);
            pelicula = new Movie(5, "Spider-Man: Un nuevo universo", "Luego de ser mordido por una araña radioactiva, el joven Miles Morales desarrolla misteriosos poderes que lo transforman en el Hombre Araña. Ahora deberá usar sus nuevas habilidades ante el malvado Kingpin, un enorme demente que puede abrir portales hacia otros universos.", new DateTime(2018, 12, 21), "http://t0.gstatic.com/images?q=tbn:ANd9GcQyfxXHWbpUJOUSgnBv2AyF0uL1Br9P3b_Erf1uB_gG8yZHUiv-");
            AuthorList.Add(pelicula);

            return AuthorList.ToList();
        }
    }
}
