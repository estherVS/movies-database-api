using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Api.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public string? Status { get; set; }
        public string? ReleaseDate { get; set; }
        public decimal? Revenue { get; set; } 
        public int? Runtime { get; set; }
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; } 
        public decimal? Budget { get; set; }
        public string? Homepage { get; set; } 
        public string? ImdbId { get; set; } 
        public string? OriginalLanguage { get; set; } 
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; } 
        public decimal? Popularity { get; set; }
        public string? PosterPath { get; set; } 
        public string? Tagline { get; set; } 
        public string? Genres { get; set; } 
        public string? ProductionCompanies { get; set; } 
        public string? ProductionCountries { get; set; } 
        public string? SpokenLanguages { get; set; } 
        public string? Keywords { get; set; } 
    }
}