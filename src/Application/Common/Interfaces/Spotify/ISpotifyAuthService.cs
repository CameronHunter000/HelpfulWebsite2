using System.Threading;
using System.Threading.Tasks;

namespace HelpfulWebsite_2.Application.Common.Interfaces.Spotify
{
    public interface ISpotifyAuthService
    {
        Task SetAuthHeader(CancellationToken cancellationToken);
    }
}