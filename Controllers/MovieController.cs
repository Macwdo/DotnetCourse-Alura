using AutoMapper;
using DOTNET6_COURSE_WEB_API.Data;
using DOTNET6_COURSE_WEB_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET6_COURSE_WEB_API.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController: ControllerBase
{

    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(
        MovieContext context,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Add movie to database
    /// </summary>
    /// <param name="movieDto">
    ///     object with necessary fields to create the movie
    /// </param>
    /// <returns>IActionResult</returns>
    /// <response code="201"> if movie additioned with success </response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        var movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new {id = movie.Id}, movie);
    }

    [HttpGet]
    public IEnumerable<ReadMovieDto> GetAll(
        [FromQuery] string? movieTitle = null,
        [FromQuery] string? movieKind = null,
        [FromQuery] int skip = 0,
        [FromQuery] int take = 10)
    {

        var moviesQuery = _context.Movies.Skip(0).Take(100); // -> Paginação direta no banco.
        
        // var moviesQuery = _context.Movies.AsQueryable(); // -> Retorno de IQuerable.
        
        // And
        // if (movieTitle != null)
        //     moviesQuery = moviesQuery.Where(movie => movie.Title == movieTitle);
        //
        // if (movieKind != null)
        //     moviesQuery = moviesQuery.Where(movie => movie.Kind == movieKind);

        // Or

        if (movieTitle != null || movieKind != null)
        {
            moviesQuery = moviesQuery.Where(movie =>
                (movieTitle != null || movie.Title == movieTitle) ||
                (movieKind != null || movie.Kind == movieKind)
            );
        }
        
            
            
        return _mapper.Map<IEnumerable<ReadMovieDto>>(moviesQuery.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
        var movieDto = _mapper.Map<ReadMovieDto>(movie);
        return Ok(movieDto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateMovieDto movieDto)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
        _mapper.Map(movieDto, movie);
        _context.SaveChanges();

        return NoContent();
    }
    
    [HttpPatch("{id}")]
    public IActionResult PartialUpdate(int id, [FromBody] JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
    
        var movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);
            
        patch.ApplyTo(movieToUpdate, ModelState);
        if (!TryValidateModel(movieToUpdate))
            return ValidationProblem(ModelState);

        _mapper.Map(movieToUpdate, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
        _context.Remove(movie);
        _context.SaveChanges();
        return NoContent();

    }

}