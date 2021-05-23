using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HelpfulWebsite_2.Application.Common.Interfaces;
using HelpfulWebsite_2.Application.Common.Interfaces.Spotify;

namespace HelpfulWebsite_2.Application.Spotify.Queries.SpotifySearch
{
    public class SpotifySearchQueryHandler : IRequestHandler<SpotifySearchQuery, SpotifySearchResponse>
    {
        private readonly ISpotifySearch _spotifySearch;

        public SpotifySearchQueryHandler(ISpotifySearch spotifySearch)
        {
            _spotifySearch = spotifySearch;
        }

        public Task<SpotifySearchResponse> Handle(SpotifySearchQuery request, CancellationToken cancellationToken)
        {
            return _spotifySearch.GetSearchResults(request, cancellationToken);
        }
    }
}