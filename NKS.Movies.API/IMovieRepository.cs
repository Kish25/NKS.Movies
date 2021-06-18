namespace NKS.Movies.API
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts;

    public interface IMovieRepository
    {
        void Create(Metadata movies);
        IEnumerable<Metadata> GetAsync(int movieId);
        IEnumerable<Metadata> GetAllAsync();
        List<MovieStats> GetStats();
    }
}