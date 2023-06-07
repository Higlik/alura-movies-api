using alura_movies_api.Data;
using alura_movies_api.Data.Dtos;
using alura_movies_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace alura_movies_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper; 

    public AddressController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddAddress([FromBody] CreateAddressDto addressDto)
    {
        Address address = _mapper.Map<Address>(addressDto);
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAddressById), new { id = address.Id}, address);
    }

    [HttpGet]
    public IEnumerable<ReadAddressDto> GetAllAddresses()
    {
        return _mapper.Map<List<ReadAddressDto>>(_context.Addresses.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(int id)
    {
        Address address = _context.Addresses.FirstOrDefault(
            address => address.Id == id);
        if(address == null) return NotFound();
        ReadAddressDto addressDto = _mapper.Map<ReadAddressDto>(address);
        return Ok(addressDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(int id,[FromBody] UpdateAddressDto addressDto)
    {
        Address address = _context.Addresses.FirstOrDefault(
        address => address.Id == id);
        if(address == null) return NotFound();
        _mapper.Map(addressDto,address);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        Address address = _context.Addresses.FirstOrDefault(
        address => address.Id == id);
        if(address == null) return NotFound();
        _context.Remove(address);
        _context.SaveChanges();
        return NoContent();
    }

    
}