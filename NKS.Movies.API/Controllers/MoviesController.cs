namespace NKS.Movies.API.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    //    [Authorize]
    [ApiController]
    [Route("[controller]")]

    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            var movie = _movieRepository.GetAllAsync()
                .GroupBy(m=>m.MovieId)
                .Select(r=> new
                {
                    MovieId=r.Key,
                    Title = r.FirstOrDefault().Title,
                    ReleaseYear = r.FirstOrDefault().ReleaseYear
                })
                .OrderByDescending(r=>r.ReleaseYear);

            var result = _movieRepository.GetStats();

            var avg = result
                      .GroupBy(m => m.MovieId)
                      .Select(r => new
                      {
                          MovieId = r.First().MovieId,
                          Watches = r.Count(),
                          AverageWatchDurationS = r.Sum(s => s.WatchDurationMs/1000) 

                      }).ToList();

            var combineResult = (from m in movie
                                 join a in avg
                                     on m.MovieId equals a.MovieId
                                 select new
                                 {
                                     MovieId = m.MovieId,
                                     Title = m.Title,
                                     AverageWatchDurationS = a.AverageWatchDurationS / 1000,
                                     Watches = a.Watches,
                                     ReleaseYear = m.ReleaseYear
                                 }).ToList()
                .OrderByDescending(w=>w.Watches)
                .ThenByDescending(r=>r.ReleaseYear);


            return Ok(combineResult);
        }

        
    }
}
