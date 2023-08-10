using System.Collections;
using AutoMapper;
using DOTNET6_COURSE_WEB_API.Data;
using DOTNET6_COURSE_WEB_API.Data.Dtos.Cinema;
using DOTNET6_COURSE_WEB_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET6_COURSE_WEB_API.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController: ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public CinemaController(
        MovieContext context,
        IMapper mapper
    )
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        var cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new {id = cinema.Id}, cinema);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> GetAll([FromQuery]int skip = 0, [FromQuery]int take = 10)
    {
        
        return _mapper.Map<IEnumerable<ReadCinemaDto>>(_context.Cinemas.Skip(skip).Take(take).ToList());;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(m => m.Id == id);
        if (cinema == null) return NotFound();
        var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Ok(cinemaDto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(m => m.Id == id);
        if (cinema == null) return NotFound();
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();

        return NoContent();
    }
    
    [HttpPatch("{id}")]
    public IActionResult PartialUpdate(int id, [FromBody] JsonPatchDocument<UpdateCinemaDto> patch)
    {
        var cinema = _context.Cinemas.FirstOrDefault(m => m.Id == id);
        if (cinema == null) return NotFound();
    
        var cinemaToUpdate = _mapper.Map<UpdateCinemaDto>(cinema);
            
        patch.ApplyTo(cinemaToUpdate, ModelState);
        if (!TryValidateModel(cinemaToUpdate))
            return ValidationProblem(ModelState);

        _mapper.Map(cinemaToUpdate, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(m => m.Id == id);
        if (cinema == null) return NotFound();
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();

    }



}