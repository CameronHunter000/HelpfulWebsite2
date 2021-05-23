using HelpfulWebsite_2.Application.Common.Models.Spotify;
using System.Threading;
using System.Threading.Tasks;

namespace HelpfulWebsite_2.Application.Common.Interfaces.Spotify
{
    public interface ISpotifySearch
    {
        Task<SpotifySearchResponse> GetSearchResults(CancellationToken cancellationToken);
    }
}