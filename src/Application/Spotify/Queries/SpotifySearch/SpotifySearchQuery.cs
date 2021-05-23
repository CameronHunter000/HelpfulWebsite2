using MediatR;

namespace HelpfulWebsite_2.Application.Spotify.Queries.SpotifySearch
{
    public class SpotifySearchQuery : IRequest<SpotifySearchResponse>
    {
        public string SearchText { get; set; }

        public EType Type { get; set; }

        public EMarket Market { get; set; } = EMarket.GB;

        public int Limit { get; set; } = 20;

        public int Offset { get; set; } = 0;

        public string IncludeExternal { get; set; }

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
