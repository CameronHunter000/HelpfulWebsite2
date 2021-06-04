using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading;
using System.Text.Json;
using AutoMapper;
using HelpfulWebsite_2.Application.Common.Interfaces.Music;
using HelpfulWebsite_2.Application.Music.Queries.MusicSearch;
using HelpfulWebsite_2.Infrastructure.Utils;
using HelpfulWebsite_2.Application.Common.Models;
using HelpfulWebsite_2.Infrastructure.Mappings;
using HelpfulWebsite_2.Infrastructure.Models.Spotify.SpotifySearch;
using HelpfulWebsite_2.Infrastructure.Models.Spotify.SpotifySearch.ResponseModel;

namespace HelpfulWebsite_2.Infrastructure.Services.Spotify
{
    public class SpotifySearchService : IMusicSearchService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IMusicAuthService _spotifyAuthService;
        private readonly IMapper _mapper;


        public SpotifySearchService(IConfiguration configuration,
            HttpClient httpClient,
            IMusicAuthService spotifyAuthService,
            IMapper mapper)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _spotifyAuthService = spotifyAuthService;
            _mapper = mapper;
        }

        public class SpotifySearchServiceException : Exception
        {
            public SpotifySearchServiceException(string message) 
                : base(message) { }
        }

        public async Task<TrackListDto> GetSearchResults(MusicSearchQuery musicSearchQuery, 
            CancellationToken cancellationToken) =>
                await GetResponseFromService<TrackListDto>(musicSearchQuery, cancellationToken);

        private async Task<TrackListDto> GetResponseFromService<T>(MusicSearchQuery musicSearchQuery, 
            CancellationToken cancellationToken)
        {
            var queryObject = MusicMapper.GetSpotifySearchQuery(musicSearchQuery);

            await _spotifyAuthService.SetAuthHeader(cancellationToken);

            var url = _configuration["Spotify:Url"];
            var path = "search";
            var queryString = HelperMethods.GetQueryString(queryObject);

            var response =
                await _httpClient.GetAsync(
                    $"{url}{path}?{queryString}",
                    cancellationToken);

            var searchResponse = await Deserialize<SpotifySearchResponse>(response, cancellationToken);

            return MusicMapper.GetTrackList(searchResponse);
        }   

        private static async Task<T> Deserialize<T>(HttpResponseMessage response,
            CancellationToken cancellationToken)
        {
            await using var contentStream =
                await response.Content.ReadAsStreamAsync(cancellationToken);

            var jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                PropertyNameCaseInsensitive = true
            };

            return await JsonSerializer.DeserializeAsync<T>(contentStream,
                jsonSerializerOptions,
                cancellationToken);
        }
    }
}
