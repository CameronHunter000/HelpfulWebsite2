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
using HelpfulWebsite_2.Application.Common.Interfaces.Music;
using System.Text.Json.Serialization;

namespace HelpfulWebsite_2.Infrastructure.Services.Spotify
{
    public class SpotifyAuthService : IMusicAuthService
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
            public SpotifyAuthServiceException(string message) 
                : base(message) { }
        }

        public async Task SetAuthHeader(CancellationToken cancellationToken) =>
            await GetResponseFromService(cancellationToken);

        private async Task GetResponseFromService(CancellationToken cancellationToken)
        {
            var clientId = _configuration["Spotify:clientId"];
            var clientSecret = _configuration["Spotify:clientSecret"];
            var url = _configuration["Spotify:TokenUrl"];

            var content = new Dictionary<string, string> {
                {"grant_type", "client_credentials"}
            };
            var urlEncodedContent = new FormUrlEncodedContent(content);

            _httpClient.DefaultRequestHeaders.Authorization = 
                GetHeaderForAuthTokenRequest(clientId, clientSecret);

            var response = await _httpClient.PostAsync(url,
                urlEncodedContent, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new SpotifyAuthServiceException(
                    $"{nameof(SetAuthHeader)} failed with http status code {response.StatusCode}");
            }

            var authToken = await Deserialize<SpotifyAuthToken>(response, cancellationToken);

            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue(authToken.TokenType, authToken.AccessToken);
        }

        private static AuthenticationHeaderValue GetHeaderForAuthTokenRequest(string clientId, string clientSecret)
        {
            var encodedParameter = Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}");
            var base64EncodedParameter = Convert.ToBase64String(encodedParameter);

            return new AuthenticationHeaderValue("Basic", base64EncodedParameter);
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
            [JsonPropertyName("access_token")]
            public string AccessToken { get; set; }

            [JsonPropertyName("token_type")]
            public string TokenType { get; set; }

            [JsonPropertyName("expires_in")]
            public int ExpiresIn { get; set; }
        }
    }
}