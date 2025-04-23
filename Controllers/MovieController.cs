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

    [HttpPut]
    [Route("{id}")]

    public IActionResult Update([FromRoute] int id, [FromBody] UpdateMovieRequestDto updateDto)
    {
        var movieModel = _context.Movies.FirstOrDefault(x => x.Id == id);

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

        _context.SaveChanges();

        return Ok(movieModel.ToMovieDto());
    }

}
}