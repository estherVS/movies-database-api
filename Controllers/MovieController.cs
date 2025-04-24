using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Data;
using Movies.Api.DTOs.Movie;
using Movies.Api.Interfaces;
using Movies.Api.Mappers;

namespace Movies.Api.Controllers
{
    [Route("api/Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMovieRepository _movieRepo;
        public MovieController(ApplicationDBContext context, IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
            _context = context;
        }
    

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var movies = await _movieRepo.GetAllAsync();
        
        var movieDto = movies.Select(s => s.ToMovieDto());

        return Ok(movieDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var movie = await _movieRepo.GetByIdAsync(id);

        if(movie == null)
        {
            return NotFound();
        }

        return Ok(movie.ToDetailedMovieDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMovieRequestDto movieDto)
    {
        var movieModel = movieDto.ToMovieFromCreateDto();
        await _movieRepo.CreateAsync(movieModel);
        return CreatedAtAction(nameof(GetById), new {id = movieModel.Id}, movieModel.ToMovieDto());
    }

    [HttpPut]
    [Route("{id}")]

    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMovieRequestDto updateDto)
    {
        var movieModel = await _movieRepo.UpdateAsync(id, updateDto);

        if(movieModel == null)
        {
            return NotFound();
        }

        return Ok(movieModel.ToMovieDto());
    }

    [HttpDelete]
    [Route("{id}")]

    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var movieModel = await _movieRepo.DeleteAsync(id);

        if(movieModel == null)
        {
            return NotFound();
        }

        return NoContent();
    }

}
}