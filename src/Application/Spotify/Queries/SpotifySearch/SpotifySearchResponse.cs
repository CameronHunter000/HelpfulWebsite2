using System.Collections.Generic;
using MediatR;

namespace HelpfulWebsite_2.Application.Spotify.Queries.SpotifySearch
{
    public class SpotifySearchResponse
    {
        public Artists Artists { get; set; }
        public Tracks Tracks { get; set; }
    }

    public class ExternalUrls
    {
        public string Spotify { get; set; }
    }
    public class Followers
    {
        public object Href { get; set; }
        public int Total { get; set; }
    }
    public class Image
    {
        public int Height { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }
    public class Item
    {
        public ExternalUrls ExternalUrls { get; set; }
        public Followers Followers { get; set; }
        public List<string> Genres { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        public Album Album { get; set; }
        public List<Artists> Artists { get; set; }
        public int DiscNumber { get; set; }
        public int DurationMs { get; set; }
        public bool Explicit { get; set; }
        public ExternalIds ExternalIds { get; set; }
        public bool IsLocal { get; set; }
        public bool IsPlayable { get; set; }
        public string PreviewUrl { get; set; }
        public int TrackNumber { get; set; }
    }
    public class Artists
    {
        public string Href { get; set; }
        public List<Item> Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public string Previous { get; set; }
        public int Total { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class Album
    {
        public string AlbumType { get; set; }
        public List<Artists> Artists { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string ReleaseDatePrecision { get; set; }
        public int TotalTracks { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
    public class ExternalIds
    {
        public string Isrc { get; set; }
    }
    public class Tracks
    {
        public string Href { get; set; }
        public List<Item> Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public string Previous { get; set; }
        public int Total { get; set; }
    }
}