using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HelpfulWebsite_2.Infrastructure.Models.Spotify.SpotifySearch.ResponseModel
{
    public class Artists
    {
        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }

        public List<ArtistItem> Items { get; set; }

        public int? Limit { get; set; }

        public string Next { get; set; }

        public int? Offset { get; set; }

        public object Previous { get; set; }

        public int? Total { get; set; }
    }

    public class ArtistItem : Item { }
}