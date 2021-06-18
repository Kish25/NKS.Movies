namespace NKS.Movies.API.Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Configuration;
    using Contracts;
    using Dapper;
    using Extensions;
    using File;
    using Microsoft.Extensions.Options;

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
