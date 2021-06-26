using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using NKS.Movies.API.Configuration;
using NKS.Movies.API.Contracts;
using NKS.Movies.API.Extensions;
using NKS.Movies.API.Infrastructure.File;

namespace NKS.Movies.API.Infrastructure.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesConfiguration _options;

        public MovieRepository(IOptions<MoviesConfiguration> options)
        {
            _options = options.Value;
        }

        public void Create(Metadata movies)
        {
            if (!movies.Duration.IsValidTimeFormat())
                throw new FormatException("Duration is not in correct format.");
            var metaData= TextFileProcessor.LoadFromTextFile<Metadata>(_options.MetadataFile);

            metaData.Add(movies);
        }

        private static bool IsValidDuration(string duration)
        {
            TimeSpan output;
            return TimeSpan.TryParse(duration, out output);
        }

        public IEnumerable<Metadata> GetAsync(int id)
        {

            return TextFileProcessor.LoadFromTextFile<Metadata>(_options.MetadataFile)
                                                      .Where(m => m.MovieId == id);
        }

        public IEnumerable<Metadata> GetAllAsync()
        {
            return TextFileProcessor.LoadFromTextFile<Metadata>(_options.MetadataFile);
        }

        public List<MovieStats> GetStats()
        {
            var stats =TextFileProcessor.LoadFromTextFile<MovieStats>(_options.StatsFile);

            return stats;
        }
    }
}
