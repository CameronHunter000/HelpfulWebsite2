using System.Threading;
using System.Threading.Tasks;

namespace HelpfulWebsite_2.Application.Common.Interfaces.Music
{
    public interface IMusicAuthService
    {
        Task SetAuthHeader(CancellationToken cancellationToken);
    }
}