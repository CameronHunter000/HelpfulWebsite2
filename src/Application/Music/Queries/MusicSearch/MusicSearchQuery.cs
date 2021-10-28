using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HelpfulWebsite_2.Application.Common.Interfaces.Music;

namespace HelpfulWebsite_2.Application.Music.Queries.MusicSearch
{

    public class MusicSearchQuery : IRequest<TrackListDto>
    {
        public string SearchText { get; set; }

        public string ResultType { get; set; } = "track";

    }
    public class MusicSearchQueryHandler : IRequestHandler<MusicSearchQuery, TrackListDto>
    {
        private readonly IMusicSearchService _musicSearch;

        public MusicSearchQueryHandler(IMusicSearchService musicSearch)
        {
            _musicSearch = musicSearch;
        }

        public Task<TrackListDto> Handle(MusicSearchQuery request, CancellationToken cancellationToken)
        {
            return _musicSearch.GetSearchResults(request, cancellationToken);
        }
    }
}