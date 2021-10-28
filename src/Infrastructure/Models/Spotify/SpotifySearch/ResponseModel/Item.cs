using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HelpfulWebsite_2.Infrastructure.Models.Spotify.SpotifySearch.ResponseModel
{
    public class Item
    {
        [JsonPropertyName("album_type")]
        public string AlbumType { get; set; }

        public List<Artists> Artists { get; set; }

        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public List<Image> Images { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("release_date_precision")]
        public string ReleaseDatePrecision { get; set; }

        [JsonPropertyName("total_tracks")]
        public int? TotalTracks { get; set; }

        public string Type { get; set; }

        public Uri Uri { get; set; }

        public Followers Followers { get; set; }

        public List<string> Genres { get; set; }

        public int? Popularity { get; set; }

        public Album Album { get; set; }

        [JsonPropertyName("disc_number")]
        public int? DiscNumber { get; set; }

        [JsonPropertyName("duration_ms")]
        public int? DurationMs { get; set; }

        [JsonPropertyName("@explicit")]
        public bool Explicit { get; set; }

        [JsonPropertyName("external_ids")]
        public ExternalIds ExternalIds { get; set; }

        [JsonPropertyName("is_local")]
        public bool IsLocal { get; set; }

        [JsonPropertyName("is_playable")]
        public bool IsPlayable { get; set; }

        [JsonPropertyName("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonPropertyName("track_number")]
        public int? TrackNumber { get; set; }

        public bool Collaborative { get; set; }

        public string Description { get; set; }

        public Owner Owner { get; set; }

        [JsonPropertyName("primary_color")]
        public object PrimaryColor { get; set; }

        [JsonPropertyName("@public")]
        public object Public { get; set; }

        [JsonPropertyName("snapshot_id")]
        public string SnapshotId { get; set; }

        public Tracks Tracks { get; set; }

        [JsonPropertyName("available_markets")]
        public List<string> AvailableMarkets { get; set; }

        public List<object> Copyrights { get; set; }

        [JsonPropertyName("html_description")]
        public string HtmlDescription { get; set; }

        [JsonPropertyName("is_externally_hosted")]
        public bool IsExternallyHosted { get; set; }

        public List<string> Languages { get; set; }

        [JsonPropertyName("media_type")]
        public string MediaType { get; set; }

        public string Publisher { get; set; }

        [JsonPropertyName("total_episodes")]
        public int? TotalEpisodes { get; set; }

        [JsonPropertyName("audio_preview_url")]
        public string AudioPreviewUrl { get; set; }

        public string Language { get; set; }

        public Restriction Restriction { get; set; }
    }

    public class Album
    {
        [JsonPropertyName("album_type")]
        public string AlbumType { get; set; }

        public List<Artists> Artists { get; set; }

        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public List<Image> Images { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("release_date_precision")]
        public string ReleaseDatePrecision { get; set; }

        [JsonPropertyName("total_tracks")]
        public int? TotalTracks { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }

    public class Followers
    {
        public object Href { get; set; }

        public int? Total { get; set; }
    }

    public class ExternalIds
    {
        public string Isrc { get; set; }
    }

    public class Owner
    {
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }

        public string Href { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        public string Uri { get; set; }
    }

    public class Restriction
    {
        public string Reason { get; set; }
    }

    public class Image
    {
        public int? Height { get; set; }

        public string Url { get; set; }

        public int? Width { get; set; }
    }
}