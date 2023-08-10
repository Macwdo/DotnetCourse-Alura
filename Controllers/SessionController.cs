using System.Collections;
using AutoMapper;
using DOTNET6_COURSE_WEB_API.Data;
using DOTNET6_COURSE_WEB_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET6_COURSE_WEB_API.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController: ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public SessionController(
        MovieContext context,
        IMapper mapper
    )
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddSession([FromBody] CreateSessionDto sessionDto)
    {
        var session = _mapper.Map<Session>(sessionDto);
        _context.Sessions.Add(session);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new {CinemaId = session.CinemaId, MovieId = session.MovieId}, session);
    }

    [HttpGet]
    public IEnumerable<ReadSessionDto> GetAll([FromQuery]int skip = 0, [FromQuery]int take = 10)
    {
        
        return _mapper.Map<IEnumerable<ReadSessionDto>>(_context.Sessions.ToList());;
    }

    [HttpGet("{cinemaId:int}/{movieId:int}")]
    public IActionResult GetById(int cinemaId, int movieId)
    {
        var session = _context.Sessions.FirstOrDefault(
            s => s.CinemaId == cinemaId && s.MovieId == movieId
            );
        if (session == null) return NotFound();
        var sessionDto = _mapper.Map<ReadSessionDto>(session);
        return Ok(sessionDto);
    }

    [HttpDelete("{cinemaId:int}/{movieId:int}")]
    public IActionResult Delete(int cinemaId, int movieId)
    {
        var session = _context.Sessions.FirstOrDefault(
            s => s.CinemaId == cinemaId && s.MovieId == movieId
        );        if (session == null) return NotFound();
        _context.Remove(session);
        _context.SaveChanges();
        return NoContent();

    }



}