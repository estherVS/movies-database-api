using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Api.DTOs.Movie;
using Movies.Api.Helpers;
using Movies.Api.Models;

namespace Movies.Api.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync(MovieQueryParameters search);
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie> CreateAsync (Movie movieModel);
        Task<Movie?> UpdateAsync(int id, UpdateMovieRequestDto movieDto);
        Task<Movie?> DeleteAsync(int id);
   }
}