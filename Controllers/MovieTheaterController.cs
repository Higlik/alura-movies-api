using alura_movies_api.Data;
using alura_movies_api.Data.Dtos;
using alura_movies_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace alura_movies_api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieTheaterController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public MovieTheaterController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddMovieTheater(
        [FromBody]CreateMovieTheaterDto movieTheaterDto)
    {
        MovieTheater movieTheater = _mapper.Map<MovieTheater>(movieTheaterDto);
        _context.MovieTheaters.Add(movieTheater);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieTheaterById),
         new {id = movieTheater.Id}, movieTheater);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieTheaterById(int id)
    {
        var movieTheater = _context.MovieTheaters.FirstOrDefault(
            movieTheater => movieTheater.Id == id);
        if(movieTheater == null) return NotFound();
        var movieTheaterDto = _mapper.Map<ReadMovieTheaterDto>(movieTheater);
        return Ok(movieTheaterDto);
    }

    [HttpGet]
    public IEnumerable<ReadMovieTheaterDto> GetAllMovieTheaters()
        {
            return _mapper.Map<List<ReadMovieTheaterDto>>(
                _context.MovieTheaters.ToList());
        }

    [HttpPut("{id}")]
    public IActionResult UpdateMovieTheater(
        int id,[FromBody]UpdateMovieTheaterDto movieTheaterDto)
        {
            var movieTheater = _context.MovieTheaters.FirstOrDefault(
                movieTheater => movieTheater.Id == id);
            if(movieTheater == null) return NotFound();
            _mapper.Map(movieTheaterDto, movieTheater);
            _context.SaveChanges();
            return NoContent();
        }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovieTheater(int id)
    {
        var movieTheater = _context.MovieTheaters.FirstOrDefault(
            movieTheater => movieTheater.Id == id);
        if(movieTheater == null) return NotFound();
        _context.Remove(movieTheater);
        _context.SaveChanges();
        return NoContent();

    }

}