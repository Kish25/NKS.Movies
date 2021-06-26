using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NKS.Movies.API.Contracts;
using Serilog;

namespace NKS.Movies.API.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MetadataController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        /// <summary>
        /// returns movie meta data for given movie id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult Get([Required] int id)
        {
            //if (id.Equals(null) || id < 1)
            //    return BadRequest("must provide some id");

            var movie = _movieRepository.GetAsync(id);

            if (movie.Equals(null))
                return NotFound($"Movie metadata does not exist for id={id}");

            var response = (from m in movie
                select new MetadataResponse
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Language = m.Language,
                    Duration = m.Duration,
                    ReleaseYear = m.ReleaseYear
                }).ToList();
            return Ok(response);
        }

        /// <summary>
        ///     adds new meta data about movie
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult Post([FromBody] MetadataRequest request)
        {
            try
            {
                var domainRequest = new Metadata
                {
                    MovieId = request.MovieId,
                    Title = request.Title,
                    Language = request.Language,
                    Duration = request.Duration,
                    ReleaseYear = request.ReleaseYear
                };
                _movieRepository.Create(domainRequest);
                return Ok("Some uri");
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
