using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NKS.Movies.API.Contracts
{
    public class Metadata
    {
        //public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
        public int ReleaseYear { get; set; }
        public List<MetadataResponse> MaptoResponse(List<Metadata> metaData)
        {
            var response = new List<MetadataResponse>();
            foreach (var data in metaData)
            {
                response.Add
                    ( new MetadataResponse()
                     {
                        MovieId=data.MovieId,
                        Title=data.Title,
                        Language=data.Language,
                        Duration=data.Duration,
                        ReleaseYear=data.ReleaseYear
                     });
            }

            return response;
        }
    }


}
