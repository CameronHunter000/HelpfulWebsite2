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
using HelpfulWebsite_2.Application.Spotify.Queries.SpotifySearch;
using System.Collections;
using System.IO;
using System.Web;

namespace HelpfulWebsite_2.Infrastructure.Services.Spotify
{
    public class SpotifySearchService : ISpotifySearchService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ISpotifyAuthService _spotifyAuthService;

        public SpotifySearchService(IConfiguration configuration,
            HttpClient httpClient,
            ISpotifyAuthService spotifyAuthService)
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

        public async Task<SpotifySearchResponse> GetSearchResults(SpotifySearchQuery spotifySearchQuery, 
            CancellationToken cancellationToken) =>
            await GetResponseFromService<SpotifySearchResponse>(spotifySearchQuery, cancellationToken);

        private async Task<T> GetResponseFromService<T>(SpotifySearchQuery spotifySearchQuery, 
            CancellationToken cancellationToken)
        {
            await _spotifyAuthService.SetAuthHeader(cancellationToken);
            var url = _configuration["Spotify:Url"];
            var path = "search";
            var query = GetQueryString<SpotifySearchQuery>(spotifySearchQuery);

            var response =
                await _httpClient.GetAsync(
                    $"{url}{path}?{query}",
                    cancellationToken);

            return await Deserialize<T>(response, cancellationToken);
        }   

        private static async Task<T> Deserialize<T>(HttpResponseMessage response,
            CancellationToken cancellationToken)
        {
            await using var contentStream =
                await response.Content.ReadAsStreamAsync(cancellationToken);

            var jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            return await JsonSerializer.DeserializeAsync<T>(contentStream,
                jsonSerializerOptions,
                cancellationToken);
        }

        public static string GetQueryString<T>(SpotifySearchQuery query)
        {
            var properties = 
                from p in typeof(T).GetProperties()
                where p.GetValue(query) != null
                // ReSharper disable twice PossibleNullReferenceException - it's handled by the line above
                select p.Name.ToLower() + "=" + HttpUtility.UrlEncode(p.GetValue(query).ToString().ToLower());

            return string.Join("&", properties.ToArray());
        }
    }
}
