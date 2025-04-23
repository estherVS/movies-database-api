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
    public async Task<IActionResult> GetAll()
    {
        var movies = await _context.Movies.ToListAsync();
        
        var movieDto = movies.Select(s => s.ToMovieDto());

        return Ok(movieDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var movie = await _context.Movies.FindAsync(id);

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
        await _context.Movies.AddAsync(movieModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new {id = movieModel.Id}, movieModel.ToMovieDto());
    }

    [HttpPut]
    [Route("{id}")]

    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMovieRequestDto updateDto)
    {
        var movieModel = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

        if(movieModel == null)
        {
            return NotFound();
        }

        movieModel.Title = updateDto.Title;
        movieModel.VoteAverage = updateDto.VoteAverage;
        movieModel.VoteCount = updateDto.VoteCount;
        movieModel.Status = updateDto.Status;
        movieModel.ReleaseDate = updateDto.ReleaseDate;
        movieModel.Revenue = updateDto.Revenue;
        movieModel.Runtime = updateDto.Runtime;
        movieModel.Adult = updateDto.Adult;
        movieModel.BackdropPath = updateDto.BackdropPath;
        movieModel.Budget = updateDto.Budget;
        movieModel.Homepage = updateDto.Homepage;
        movieModel.ImdbId = updateDto.Homepage;
        movieModel.OriginalLanguage = updateDto.OriginalLanguage;
        movieModel.OriginalTitle = updateDto.OriginalTitle;
        movieModel.Overview = updateDto.Overview;
        movieModel.Popularity = updateDto.Popularity;
        movieModel.PosterPath = updateDto.PosterPath;
        movieModel.Tagline = updateDto.Tagline;
        movieModel.Genres = updateDto.Tagline;
        movieModel.ProductionCompanies = updateDto.ProductionCompanies;
        movieModel.ProductionCountries = updateDto.ProductionCountries;
        movieModel.SpokenLanguages = updateDto.SpokenLanguages;
        movieModel.Keywords = updateDto.Keywords;

        await _context.SaveChangesAsync();

        return Ok(movieModel.ToMovieDto());
    }

    [HttpDelete]
    [Route("{id}")]

    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var movieModel = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

        if(movieModel == null)
        {
            return NotFound();
        }

        _context.Movies.Remove(movieModel);

        await _context.SaveChangesAsync();

        return NoContent();
    }

}
}