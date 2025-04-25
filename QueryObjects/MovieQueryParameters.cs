using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Api.QueryObjects 
{
    public class MovieQueryParameters
    {
        public string? Title { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;
        [Required]
        [Range(1, 100)]
        public int PageSize { get; set; } = 10;
    }

    
}