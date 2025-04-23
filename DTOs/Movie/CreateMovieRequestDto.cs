using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Api.DTOs.Movie
{
    public class CreateMovieRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public string? ReleaseDate { get; set; }
        public int? Runtime { get; set; }
        public string? Overview { get; set; } 
        public string? Genres { get; set; } 
        
    }
}