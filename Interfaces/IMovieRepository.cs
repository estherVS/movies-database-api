using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Api.DTOs.Movie;
using Movies.Api.Models;

namespace Movies.Api.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie> CreateAsync (Movie movieModel);
        Task<Movie?> UpdateAsync(int id, UpdateMovieRequestDto movieDto);
        Task<Movie?> DeleteAsync(int id);
   }
}