using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Data;
using Movies.Api.DTOs.Movie;
using Movies.Api.Interfaces;
using Movies.Api.Models;

namespace Movies.Api.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDBContext _context;
        public MovieRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Movie> CreateAsync(Movie movieModel)
        {
            await _context.Movies.AddAsync(movieModel);
            await _context.SaveChangesAsync();
            return movieModel;
        }

        public async Task<Movie?> DeleteAsync(int id)
        {
            var movieModel = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if(movieModel == null)
            {
                return null;
            }

            _context.Movies.Remove(movieModel);

            await _context.SaveChangesAsync();
            return movieModel;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie?> UpdateAsync(int id, UpdateMovieRequestDto movieDto)
        {
            var existingMovie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if(existingMovie == null)
            {            
                return null;
            }

            existingMovie.Title = movieDto.Title;
            existingMovie.VoteAverage = movieDto.VoteAverage;
            existingMovie.VoteCount = movieDto.VoteCount;
            existingMovie.Status = movieDto.Status;
            existingMovie.ReleaseDate = movieDto.ReleaseDate;
            existingMovie.Revenue = movieDto.Revenue;
            existingMovie.Runtime = movieDto.Runtime;
            existingMovie.Adult = movieDto.Adult;
            existingMovie.BackdropPath = movieDto.BackdropPath;
            existingMovie.Budget = movieDto.Budget;
            existingMovie.Homepage = movieDto.Homepage;
            existingMovie.ImdbId = movieDto.Homepage;
            existingMovie.OriginalLanguage = movieDto.OriginalLanguage;
            existingMovie.OriginalTitle = movieDto.OriginalTitle;
            existingMovie.Overview = movieDto.Overview;
            existingMovie.Popularity = movieDto.Popularity;
            existingMovie.PosterPath = movieDto.PosterPath;
            existingMovie.Tagline = movieDto.Tagline;
            existingMovie.Genres = movieDto.Tagline;
            existingMovie.ProductionCompanies = movieDto.ProductionCompanies;
            existingMovie.ProductionCountries = movieDto.ProductionCountries;
            existingMovie.SpokenLanguages = movieDto.SpokenLanguages;
            existingMovie.Keywords = movieDto.Keywords;

            await _context.SaveChangesAsync();
            return existingMovie;
        }
    }
}