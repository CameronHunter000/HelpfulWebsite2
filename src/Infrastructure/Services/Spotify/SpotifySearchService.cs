using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading;
using System.Text.Json;
using HelpfulWebsite_2.Application.Common.Interfaces.Spotify;
using HelpfulWebsite_2.Application.Common.Models.Spotify;

namespace HelpfulWebsite_2.Infrastructure.Services.Spotify
{
    public class SpotifySearchService : ISpotifySearch
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly SpotifyAuthService _spotifyAuthService;

        public SpotifySearchService(IConfiguration configuration,
            HttpClient httpClient,
            SpotifyAuthService spotifyAuthService)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _spotifyAuthService = spotifyAuthService;
        }

        public class SpotifySearchServiceException : Exception
        {
            public SpotifySearchServiceException(string message) : base(message)
            {

            }
        }
        // this SpotifySearchQuery object needs to be created in Application
        // and then needs to be converted to a Dictionary for content
        public async Task<SpotifySearchResponse> GetSearchResults(SpotifySearchQuery spotifySearchQuery, 
            CancellationToken cancellationToken) =>
            await GetResponseFromService<SpotifySearchResponse>(spotifySearchQuery, cancellationToken);

        private async Task<T> GetResponseFromService<T>(SpotifySearchQuery spotifySearchQuery, 
            CancellationToken cancellationToken)
        {
            await _spotifyAuthService.SetAuthHeader(cancellationToken);

            var url = _configuration["Spotify:Url"];
            var path = "search";
            var content = new FormUrlEncodedContent(spotifySearchQuery);

            var response =
                await _httpClient.PostAsync(
                    $"{url}/{path}",
                    content,
                    cancellationToken);

            return await Deserialize<T>(response, cancellationToken);
        }

        private static async Task<T> Deserialize<T>(HttpResponseMessage response,
            CancellationToken cancellationToken)
        {
            await using var contentStream =
                await response.Content.ReadAsStreamAsync(cancellationToken);

            return await JsonSerializer.DeserializeAsync<T>(contentStream,
                cancellationToken: cancellationToken);
        }
    }
}
