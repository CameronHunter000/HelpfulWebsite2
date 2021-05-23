using MediatR;

namespace HelpfulWebsite_2.Application.Spotify.Queries.SpotifySearch
{
    public class SpotifySearchQuery : IRequest<SpotifySearchResponse>
    {
        public string Query { get; set; }

        public string Type { get; set; } // Valid types are one or a comma delimited list of: album , artist, playlist, track, show and episode.

        public EMarket Market { get; set; } = EMarket.GB;

        public int Limit { get; set; } = 20;

        public int Offset { get; set; } = 0;

        // ReSharper disable once InconsistentNaming
        public string Include_External { get; set; }

        public enum EMarket
        {
            // ReSharper disable once InconsistentNaming
            GB
        }

        public enum EType
        {
            Album,
            Artist,
            Playlist,
            Track,
            Show,
            Episode
        }
    }
}
