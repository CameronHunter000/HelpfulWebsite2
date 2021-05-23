using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HelpfulWebsite_2.Application.Common.Interfaces;

namespace HelpfulWebsite_2.Application.Spotify.Queries.SpotifySearch
{
    public class SpotifySearchQueryHandler : IRequestHandler<SpotifySearchQuery, SpotifySearchResponse>
    {
        private readonly IMapper _mapper;

        public SpotifySearchQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        //see Jono's bitcoin handler for the next steps
        public Task<SpotifySearchResponse> Handle(SpotifySearchQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

    }
}