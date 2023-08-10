using AutoMapper;
using DOTNET6_COURSE_WEB_API.Data;
using DOTNET6_COURSE_WEB_API.Data.Dtos.Cinema;
using DOTNET6_COURSE_WEB_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET6_COURSE_WEB_API.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController: ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public AddressController(
        MovieContext context,
        IMapper mapper
    )
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddAddress([FromBody] CreateAddressDto addressDto)
    {
        var address = _mapper.Map<Address>(addressDto);
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new {id = address.Id}, address);
    }

    [HttpGet]
    public IEnumerable<ReadAddressDto> GetAll([FromQuery]int skip = 0, [FromQuery]int take = 10)
    {
        
        return _mapper.Map<IEnumerable<ReadAddressDto>>(_context.Addresses.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var address = _context.Addresses.FirstOrDefault(m => m.Id == id);
        if (address == null) return NotFound();
        var addressDto = _mapper.Map<ReadAddressDto>(address);
        return Ok(addressDto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateAddressDto addressDto)
    {
        var address = _context.Addresses.FirstOrDefault(m => m.Id == id);
        if (address == null) return NotFound();
        _mapper.Map(addressDto, address);
        _context.SaveChanges();

        return NoContent();
    }
    
    [HttpPatch("{id}")]
    public IActionResult PartialUpdate(int id, [FromBody] JsonPatchDocument<UpdateAddressDto> patch)
    {
        var address = _context.Addresses.FirstOrDefault(m => m.Id == id);
        if (address == null) return NotFound();
    
        var addressToUpdate = _mapper.Map<UpdateAddressDto>(address);
            
        patch.ApplyTo(addressToUpdate, ModelState);
        if (!TryValidateModel(addressToUpdate))
            return ValidationProblem(ModelState);

        _mapper.Map(addressToUpdate, address);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var address = _context.Addresses.FirstOrDefault(m => m.Id == id);
        if (address == null) return NotFound();
        _context.Remove(address);
        _context.SaveChanges();
        return NoContent();

    }



}