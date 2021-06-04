using System.Collections.Generic;

namespace HelpfulWebsite_2.Infrastructure.Models.Spotify.SpotifySearch.ResponseModel
{
    public class Tracks
    {
        public string Href { get; set; }

        public List<TrackItem> Items { get; set; }

        public int? Limit { get; set; }

        public string Next { get; set; }

        public int? Offset { get; set; }

        public object Previous { get; set; }

        public int? Total { get; set; }
    }

    public class TrackItem : Item { }
}