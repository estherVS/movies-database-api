using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Movies.Api.DTOs.Movie;
using Movies.Api.Models;

namespace Movies.Api.Mappers
{
    public static class MovieMappers
    {
        public static MovieDto ToMovieDto(this Movie movieModel)
        {
            return new MovieDto
            {
                Id = movieModel.Id,
                Title = movieModel.Title,
                ReleaseDate = movieModel.ReleaseDate,
                Runtime = movieModel.Runtime,
                Overview = movieModel.Overview,
                Genres = movieModel.Genres
            };
        }

        public static DetailedMovieDto ToDetailedMovieDto(this Movie movie)
        {
            return new DetailedMovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                VoteAverage = movie.VoteAverage,
                VoteCount = movie.VoteCount,
                Status = movie.Status,
                ReleaseDate = movie.ReleaseDate,
                Revenue = movie.Revenue,
                Runtime = movie.Runtime,
                Adult = movie.Adult,
                BackdropPath = movie.BackdropPath,
                Budget = movie.Budget,
                Homepage = movie.Homepage,
                ImdbId = movie.ImdbId,
                OriginalLanguage = movie.OriginalLanguage,
                OriginalTitle = movie.OriginalTitle,
                Overview = movie.Overview,
                Popularity = movie.Popularity,
                PosterPath = movie.PosterPath,
                Tagline = movie.Tagline,
                Genres = movie.Genres,
                ProductionCompanies = movie.ProductionCompanies,
                ProductionCountries = movie.ProductionCountries,
                SpokenLanguages = movie.SpokenLanguages,
                Keywords = movie.Keywords
            };
        }

        public static Movie ToMovieFromCreateDto(this CreateMovieRequestDto movieDto)
        {
             return new Movie
             {
                Title = movieDto.Title,
                ReleaseDate = movieDto.ReleaseDate,
                Runtime = movieDto.Runtime,
                Overview = movieDto.Overview,
                Genres = movieDto.Genres
             };
        }

    }


}