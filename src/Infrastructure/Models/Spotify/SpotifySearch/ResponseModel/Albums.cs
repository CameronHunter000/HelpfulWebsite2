using System.Collections.Generic;

namespace HelpfulWebsite_2.Infrastructure.Models.Spotify.SpotifySearch.ResponseModel
{
    public class Albums
    {
        public string Href { get; set; }

        public List<AlbumItem> Items { get; set; }

        public int? Limit { get; set; }

        public string Next { get; set; }

        public int? Offset { get; set; }

        public object Previous { get; set; }

        public int? Total { get; set; }
    }

    public class AlbumItem : Item {}
}