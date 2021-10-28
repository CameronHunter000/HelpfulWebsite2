
namespace HelpfulWebsite_2.Infrastructure.Models.Spotify.SpotifySearch.ResponseModel
{
    public class SpotifySearchResponse
    {
        public Albums Albums { get; set; }

        public Artists Artists { get; set; }

        public Tracks Tracks { get; set; }

        public Playlists Playlists { get; set; }

        public Shows Shows { get; set; }

        public Episodes Episodes { get; set; }
    }
}