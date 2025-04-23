using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Data;
using Movies.Api.DTOs.Movie;
using Movies.Api.Mappers;

namespace Movies.Api.Controllers
{
    [Route("api/Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public MovieController(ApplicationDBContext context)
        {
            _context = context;
        }
    

    [HttpGet]
    public IActionResult GetAll()
    {
        var movies = _context.Movies.ToList().Select(s => s.ToMovieDto());

        return Ok(movies);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var movie = _context.Movies.Find(id);

        if(movie == null)
        {
            return NotFound();
        }

        return Ok(movie.ToDetailedMovieDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateMovieRequestDto movieDto)
    {
        var movieModel = movieDto.ToMovieFromCreateDto();
        _context.Movies.Add(movieModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new {id = movieModel.Id}, movieModel.ToMovieDto());
    }


}
}