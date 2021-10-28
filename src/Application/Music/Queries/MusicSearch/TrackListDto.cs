using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpfulWebsite_2.Application.Music.Queries.MusicSearch
{
    public class TrackListDto
    {
        public List<TrackVm> Track { get; set; }
    }

    public class TrackVm
    {
        public Guid Id { get; set; } = new Guid();

        public string TrackName { get; set; }

        public string Album { get; set; }

        public List<string> Artists { get; set; }

        public int? Popularity { get; set; }

        public string ReleaseDate { get; set; }

        public string Language { get; set; }

        public List<string> Genres { get; set; }

        public int? Duration { get; set; }

        public Uri PlayUri { get; set; }
    }
}
