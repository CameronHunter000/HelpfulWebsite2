using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace HelpfulWebsite_2.Application.Spotify.Queries.SpotifySearch
{
    public class SpotifySearchResponse
    {
        public Albums albums { get; set; }
        public Artists artists { get; set; }
        public Tracks tracks { get; set; }
        public Playlists playlists { get; set; }
        public Shows shows { get; set; }
        public Episodes episodes { get; set; }
    }

    public class ExternalUrls
        {
            public string spotify { get; set; }
        }

        public class Artists
        {
            public ExternalUrls external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
            public List<Item> items { get; set; }
            public int? limit { get; set; }
            public string next { get; set; }
            public int? offset { get; set; }
            public object previous { get; set; }
            public int? total { get; set; }
        }

        public class Image
        {
            public int? height { get; set; }
            public string url { get; set; }
            public int? width { get; set; }
        }

        public class Item
        {
            public string album_type { get; set; }
            public List<Artists> artists { get; set; }
            public ExternalUrls external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public List<Image> images { get; set; }
            public string name { get; set; }
            public string release_date { get; set; }
            public string release_date_precision { get; set; }
            public int? total_tracks { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
            public Followers followers { get; set; }
            public List<string> genres { get; set; }
            public int? popularity { get; set; }
            public Album album { get; set; }
            public int? disc_number { get; set; }
            public int? duration_ms { get; set; }
            public bool @explicit { get; set; }
            public ExternalIds external_ids { get; set; }
            public bool is_local { get; set; }
            public bool is_playable { get; set; }
            public string preview_url { get; set; }
            public int? track_number { get; set; }
            public bool collaborative { get; set; }
            public string description { get; set; }
            public Owner owner { get; set; }
            public object primary_color { get; set; }
            public object @public { get; set; }
            public string snapshot_id { get; set; }
            public Tracks tracks { get; set; }
            public List<string> available_markets { get; set; }
            public List<object> copyrights { get; set; }
            public string html_description { get; set; }
            public bool is_externally_hosted { get; set; }
            public List<string> languages { get; set; }
            public string media_type { get; set; }
            public string publisher { get; set; }
            public int? total_episodes { get; set; }
            public string audio_preview_url { get; set; }
            public string language { get; set; }
            public Restriction restriction { get; set; }
        }

        public class Albums
        {
            public string href { get; set; }
            public List<Item> items { get; set; }
            public int? limit { get; set; }
            public string next { get; set; }
            public int? offset { get; set; }
            public object previous { get; set; }
            public int? total { get; set; }
        }

        public class Followers
        {
            public object href { get; set; }
            public int? total { get; set; }
        }

        public class Album
        {
            public string album_type { get; set; }
            public List<Artists> artists { get; set; }
            public ExternalUrls external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public List<Image> images { get; set; }
            public string name { get; set; }
            public string release_date { get; set; }
            public string release_date_precision { get; set; }
            public int? total_tracks { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class ExternalIds
        {
            public string isrc { get; set; }
        }

        public class Tracks
        {
            public string href { get; set; }
            public List<Item> items { get; set; }
            public int? limit { get; set; }
            public string next { get; set; }
            public int? offset { get; set; }
            public object previous { get; set; }
            public int? total { get; set; }
        }

        public class Owner
        {
            public string display_name { get; set; }
            public ExternalUrls external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class Playlists
        {
            public string href { get; set; }
            public List<Item> items { get; set; }
            public int? limit { get; set; }
            public string next { get; set; }
            public int? offset { get; set; }
            public object previous { get; set; }
            public int? total { get; set; }
        }

        public class Shows
        {
            public string href { get; set; }
            public List<Item> items { get; set; }
            public int? limit { get; set; }
            public string next { get; set; }
            public int? offset { get; set; }
            public object previous { get; set; }
            public int? total { get; set; }
        }

        public class Restriction
        {
            public string reason { get; set; }
        }

        public class Episodes
        {
            public string href { get; set; }
            public List<Item> items { get; set; }
            public int? limit { get; set; }
            public string next { get; set; }
            public int? offset { get; set; }
            public object previous { get; set; }
            public int? total { get; set; }
        }
}