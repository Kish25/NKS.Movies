namespace NKS.Movies.API.Contracts
{
    using Newtonsoft.Json;
    public class MovieStats
    {
        [JsonProperty("movieId")]
        public int MovieId { get; set; }
        [JsonProperty("watchDurationMs")]
        public int WatchDurationMs { get; set; }
    }
}
