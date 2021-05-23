using System.Threading;
using System.Threading.Tasks;
using HelpfulWebsite_2.Application.Spotify.Queries.SpotifySearch;

namespace HelpfulWebsite_2.Application.Common.Interfaces.Spotify
{
    public interface ISpotifySearchService
    {
        Task<SpotifySearchResponse> GetSearchResults(SpotifySearchQuery spotifySearchQuery, CancellationToken cancellationToken);
    }
}