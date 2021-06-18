namespace NKS.Movies.API.Contracts
{
    public class MovieStatsResponse
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int AverageWatchDurationS { get; set; }
        public int Watches { get; set; }
        public int releaseYear { get; set; }

    }
}
