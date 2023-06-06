using alura_movies_api.Data;
using alura_movies_api.Data.Dtos;
using alura_movies_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace alura_movies_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody]CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieById), new {id = movie.Id}, movie);
        }

        [HttpGet]
        public IEnumerable<ReadMovieDto> GetAllMovies(
            [FromQuery]int skip = 0, [FromQuery] int take = 40)
        {

            return _mapper.Map<List<ReadMovieDto>>(
                _context.Movies.Skip(skip).Take(take));   
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
           var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
           if (movie == null) return NotFound();
           var movieDto = _mapper.Map<ReadMovieDto>(movie);
           return Ok(movieDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id,[FromBody]UpdateMovieDto movieDto)
        {
            var movie = _context.Movies.FirstOrDefault(
                movie => movie.Id == id);
            if(movie == null) return NotFound();
            _mapper.Map(movieDto,movie);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
                public IActionResult UpdatePartialMovie(int id, JsonPatchDocument<UpdateMovieDto> patch)
        {
            var movie = _context.Movies.FirstOrDefault(
                movie => movie.Id == id);
            if(movie == null) return NotFound();

            var movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);

            patch.ApplyTo(movieToUpdate, ModelState);

            if(!TryValidateModel(movieToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(movieToUpdate,movie);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
           var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
           if (movie == null) return NotFound();
           _context.Remove(movie);
           _context.SaveChanges();
           return NoContent();
        }
    }
}