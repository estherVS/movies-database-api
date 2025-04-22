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
        public decimal VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ReleaseDate { get; set; } = string.Empty;
        public decimal Revenue { get; set; } 
        public int Runtime { get; set; }
        public bool Adult { get; set; }
        public string BackdropPath { get; set; } = string.Empty;
        public decimal Budget { get; set; }
        public string Homepage { get; set; } = string.Empty;
        public string ImdbId { get; set; } = string.Empty;
        public string OriginalLanguage { get; set; } = string.Empty;
        public string OriginalTitle { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public decimal Popularity { get; set; }
        public string PosterPath { get; set; } = string.Empty;
        public string Tagline { get; set; } = string.Empty;
        public string Genres { get; set; } = string.Empty;
        public string ProductionCompanies { get; set; } = string.Empty;
        public string ProductionCountries { get; set; } = string.Empty;
        public string SpokenLanguages { get; set; } = string.Empty;
        public string Keywords { get; set; } = string.Empty;
    }
}