using alura_movies_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace alura_movies_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();

        [HttpPost]
        public IActionResult AddMovie([FromBody]Movie movie)
        {

            movies.Add(movie);
            return CreatedAtAction(nameof(GetById), new {id = movie.Id}, movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetAll([FromQuery]int skip = 0, [FromQuery] int take = 40)
        {
            return movies.Skip(skip).Take(take);   
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           var movie = movies.FirstOrDefault(movie => movie.Id == id);
           if (movie == null) return NotFound();
           return Ok(movie);
        }
    }
}