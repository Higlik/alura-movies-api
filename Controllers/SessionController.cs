using alura_movies_api.Data;
using alura_movies_api.Data.Dtos;
using alura_movies_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace alura_movies_api.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public SessionController(MovieContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult AddSession(CreateSessionDto sessionDto)
    {
        Session session = _mapper.Map<Session>(sessionDto);
        _context.Sessions.Add(session);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetSessionById), new {Id = session.Id}, session); 
    }

    [HttpGet("{id}")]
    public IActionResult GetSessionById(int id)
    {
        Session session = _context.Sessions.FirstOrDefault(
            session => session.Id == id);
        if(session == null) return NotFound();
        ReadSessionDto sessionDto = _mapper.Map<ReadSessionDto>(session);
        return Ok(sessionDto);
    }

    [HttpGet]
    public IEnumerable<ReadSessionDto> GetAllSessions()
    {
        return _mapper.Map<List<ReadSessionDto>>(_context.Sessions.ToList());
    }
}