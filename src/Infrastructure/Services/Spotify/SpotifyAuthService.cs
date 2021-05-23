using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using HelpfulWebsite_2.Application.Common.Interfaces.Spotify;

namespace HelpfulWebsite_2.Infrastructure.Services.Spotify
{
    public class SpotifyAuthService : ISpotifyAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public SpotifyAuthService(IConfiguration configuration,
            HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public class SpotifyAuthServiceException : Exception
        {
            public SpotifyAuthServiceException(string message) : base(message)
            {

            }
        }

        public async Task SetAuthHeader(CancellationToken cancellationToken) =>
            await GetResponseFromService(cancellationToken);

        private async Task GetResponseFromService(CancellationToken cancellationToken)
        {
            var clientId = _configuration["Spotify:clientId"];
            var clientSecret = _configuration["Spotify:clientSecret"];
            var encodedAuthHeaderParameter = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Basic", encodedAuthHeaderParameter);

            var url = _configuration["Spotify:TokenUrl"];
            var content = 
                new FormUrlEncodedContent(new Dictionary<string, string>{
                    {"grant_type", "client_credentials"}
                });

            var response = await _httpClient.PostAsync(url, 
                content, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new SpotifyAuthServiceException(
                    $"{nameof(SetAuthHeader)} failed with http status code {response.StatusCode}");
            }

            var authToken = await Deserialize<SpotifyAuthToken>(response, cancellationToken);

            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue(authToken.token_type, authToken.access_token);
        }

        private static async Task<T> Deserialize<T>(HttpResponseMessage response,
            CancellationToken cancellationToken)
        {
            await using var contentStream =
                await response.Content.ReadAsStreamAsync(cancellationToken);

            return await JsonSerializer.DeserializeAsync<T>(contentStream,
                cancellationToken: cancellationToken);
        }
        
        public class SpotifyAuthToken
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
        }
    }
}