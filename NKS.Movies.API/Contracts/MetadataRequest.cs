using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NKS.Movies.API.Contracts
{
    using System.ComponentModel.DataAnnotations;

    public class MetadataRequest
    {
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Please provide a Movie Id bigger than 0")] 
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Movie title is required.")]
        [MinLength(2,ErrorMessage= "Please provide movie title with minimum 2 letters.")]
        [MaxLength(500, ErrorMessage = "Please provide movie title up to maximum 500 letters.")]
        public string Title { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please provide movie language with minimum 2 letters.")]
        [MaxLength(10, ErrorMessage = "Please provide movie language up to maximum 10 letters.")]
        public string Language { get; set; }
        [Required]
        [RegularExpression(@"([0-1][0-3]):([0-5][0-9]):([0-5][0-9])", ErrorMessage = "Movie duration is not correct, minimum is 1 second maximum is 4 hours.")]
        public string Duration { get; set; }
        [Required]
        [Range(1700, 9999)]
        public int ReleaseYear { get; set; }
    }
}
