using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace modul8_1302204047.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<string> Stars1 = new List<string>
        {
            "Tim Robbins","Morgan Freeman","Bob Gunton","Willian Sadler"
        };
        private static List<string> Stars2 = new List<string>
        {
            "Marlon Brando","Al Pocino","James Caan","Deane Keaton"
        };
        private static List<string> Stars3 = new List<string>
        {
            "Christian Bale","Heath Ledger","Aaron Eckhart","Michael Caine"
        };

        private readonly ILogger<Movie> _logger;
        List<Movie> movies2 = new List<Movie>();

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Movie> get()
        {
            movies2.Add(new Movie("The Shawshank Redemption", "Frank Darabont", Stars1, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency."));
            movies2.Add(new Movie("The Godfather", "Francis Ford Coppola", Stars2, "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son."));
            movies2.Add(new Movie("The Dark Knight", "Christoper Nolan", Stars3, "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."));

            return movies2.ToArray();
        }
        [HttpGet("{id}")]
        public Movie GetMovieById(int id)
        {
            var moviedata = this.movies2.ElementAt(id-1);
            if (moviedata == null) return null;
            return moviedata;
        }
        [HttpPost]
        public IEnumerable<Movie> Post([FromBody]Movie movie)
        {
            movies2.Add(new Movie(movie.Title, movie.Director, movie.Stars, movie.Description));
            return movies2;
        }
        [HttpDelete]
        public string Delete(int id)
        {
            var moviedata = this.movies2.ElementAt(id - 1);
            if(moviedata == null) return "tidak bisa menemukan data";

            var isdelete = this.movies2.Remove(moviedata);
            return (isdelete) ? "the record is deleted sucessesfully" : "something happen with our system";
        }
    }
}
