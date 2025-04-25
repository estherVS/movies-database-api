using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Data;
using Movies.Api.DTOs.Movie;
using Movies.Api.QueryObjects;
using Movies.Api.Interfaces;
using Movies.Api.Mappers;

namespace Movies.Api.Controllers
{
    [Route("api/Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepo;
        public MovieController(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] MovieQueryParameters search)
    {
        var movies = await _movieRepo.GetAllAsync(search);
        
        var movieDtos = movies.Select(s => s.ToMovieDto());

        var movieCount = await _movieRepo.CountAsync(search);

        return Ok(new PaginationDto<MovieDto>
            {
                CurrentPage = search.PageNumber,
                PageSize = search.PageSize,
                TotalPages = (movieCount + search.PageSize - 1)/search.PageSize,
                TotalItems = movieCount,
                Items = movieDtos.ToList()
            }
        );
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