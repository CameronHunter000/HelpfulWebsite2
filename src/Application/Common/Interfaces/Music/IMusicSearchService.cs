using System.Threading;
using System.Threading.Tasks;
using HelpfulWebsite_2.Application.Music.Queries.MusicSearch;

namespace HelpfulWebsite_2.Application.Common.Interfaces.Music
{
    public interface IMusicSearchService
    {
        Task<TrackListDto> GetSearchResults(MusicSearchQuery musicSearchQuery, CancellationToken cancellationToken);
    }
}